using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;
using KinectMouseController;
using System.Diagnostics;

namespace KinectMouseEmulator
{
    public partial class MainWindow : Window
    {
        KinectSensor Sensor;
        Skeleton[] skeletons;
        AlgorithmicPostureDetector postureRecognizer;

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Window Events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                KinectSensor.KinectSensors.StatusChanged += Kinects_StatusChanged;

                foreach (KinectSensor kinect in KinectSensor.KinectSensors)
                {
                    if (kinect.Status == KinectStatus.Connected)
                    {
                        this.Sensor = kinect;
                        break;
                    }
                }

                if (KinectSensor.KinectSensors.Count == 0)
                    MessageBox.Show("No Kinect found");
                else
                    Initialize();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Uninitialize();
        }
        #endregion

        private void Initialize()
        {
            if (this.Sensor == null)
                return;

            this.Sensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
            this.Sensor.SkeletonFrameReady += kinectSensor_SkeletonFrameReady;

            var parameters = new TransformSmoothParameters
            {
                Smoothing = 0.3f,
                Correction = 0.0f,
                Prediction = 0.0f,
                JitterRadius = 1.0f,
                MaxDeviationRadius = 0.5f
            };
            this.Sensor.SkeletonStream.Enable(parameters);

            this.Sensor.Start();

            LoadPosturesRecognizer();
        }

        private void LoadPosturesRecognizer()
        {
            postureRecognizer = new AlgorithmicPostureDetector();
            postureRecognizer.PostureDetected += algp_PostureDetected;

            MouseController.Current.ClickGestureDetector = postureRecognizer;
        }

        void algp_PostureDetected(string posture)
        {
            if (posture == "LeftHandOverHead")
            {
                Console.WriteLine("Left hand up");
            }
        }

        private void kinectSensor_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (SkeletonFrame frame = e.OpenSkeletonFrame())
            {
                if (frame == null)
                    return;

                if (skeletons == null || skeletons.Length != frame.SkeletonArrayLength)
                {
                    skeletons = new Skeleton[frame.SkeletonArrayLength];
                }
                frame.CopySkeletonDataTo(skeletons);

                if (skeletons.All(s => s.TrackingState == SkeletonTrackingState.NotTracked))
                    return;

                foreach (var skeleton in skeletons)
                {
                    if (skeleton.TrackingState != SkeletonTrackingState.Tracked)
                        continue;

                    foreach (Joint joint in skeleton.Joints)
                    {
                        if (joint.TrackingState != JointTrackingState.Tracked)
                            continue;

                        if (joint.JointType == JointType.HandRight)
                        {
                            MouseController.Current.SetHandPosition(this.Sensor, joint, skeleton);

                            postureRecognizer.TrackPostures(skeleton);
                        }
                    }
                }
            }
        }

        void Kinects_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case KinectStatus.Connected:
                    if (this.Sensor == null)
                    {
                        this.Sensor = e.Sensor;
                        Initialize();
                    }
                    break;
                case KinectStatus.Disconnected:
                    if (this.Sensor == e.Sensor)
                    {
                        Uninitialize();
                        MessageBox.Show("Kinect was disconnected");
                    }
                    break;
                case KinectStatus.NotReady:
                    break;
                case KinectStatus.NotPowered:
                    if (this.Sensor == e.Sensor)
                    {
                        Uninitialize();
                        MessageBox.Show("Kinect is no more powered");
                    }
                    break;
                default:
                    MessageBox.Show("Unhandled Status: " + e.Status);
                    break;
            }
        }

        private void Uninitialize()
        {
            if (this.Sensor != null)
            {
                this.Sensor.Stop();
                this.Sensor = null;
            }
        }
    }
}