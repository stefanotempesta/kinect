using System.Linq;
using Microsoft.Kinect;


namespace KinectQuizDesktop.Model
{
    public class MyKinectSensor
    {
        public KinectSensor Sensor { get; private set; }

        public void Start()
        {
            // Instantiate the sensor
            this.Sensor = KinectSensor.KinectSensors
                .FirstOrDefault(x => x.Status == KinectStatus.Connected);

            Initialize();
        }

        void Initialize()
        {
            // Initialize the cameras
            this.Sensor.DepthStream.Enable();
            this.Sensor.SkeletonFrameReady += Sensor_SkeletonFrameReady;

            // Start the data streaming
            this.Sensor.Start();
        }

        void Uninitialize()
        {
            if (this.Sensor != null)
            {
                this.Sensor.Stop();
                this.Sensor = null;
            }
        }

        void Sensor_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            Skeleton[] skeletons = null;

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

                        if (joint.JointType == JointType.HandLeft || joint.JointType == JointType.HandRight)
                        {
                            _postureRecognizer.TrackPostures(joint);
                            MouseController.Current.SetHandPosition(this.Sensor, joint, skeleton);
                        }
                    }
                }
            }
        }

        void Kinect_StatusChanged(object sender, StatusChangedEventArgs e)
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

                case KinectStatus.NotReady:
                    break;

                case KinectStatus.Disconnected:
                case KinectStatus.NotPowered:
                    if (this.Sensor == e.Sensor)
                    {
                        Uninitialize();
                    }
                    break;

                default:
                    break;
            }
        }

        private AlgorithmicPostureDetector _postureRecognizer = new AlgorithmicPostureDetector();
    }
}
