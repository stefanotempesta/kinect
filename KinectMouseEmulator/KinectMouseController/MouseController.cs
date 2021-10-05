using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Kinect;

namespace KinectMouseController
{
    public class MouseController
    {
        #region Singleton
        static MouseController current;
        public static MouseController Current
        {
            get
            {
                if (current == null)
                {
                    current = new MouseController();
                }

                return current;
            }
        }
        #endregion

        #region Properties
        public float TrendSmoothingFactor
        {
            get;
            set;
        }

        public float JitterRadius
        {
            get;
            set;
        }

        public float DataSmoothingFactor
        {
            get;
            set;
        }

        public float PredictionFactor
        {
            get;
            set;
        }

        public float GlobalSmooth
        {
            get;
            set;
        }

        Vector2? lastKnownPosition;
        float previousDepth;

        // Filters
        Vector2 savedFilteredJointPosition;
        Vector2 savedTrend;
        Vector2 savedBasePosition;
        int frameCount;

        AlgorithmicPostureDetector clickPostureDetector;

        bool clickGestureDetected;
        public AlgorithmicPostureDetector ClickGestureDetector
        {
            get
            {
                return clickPostureDetector;
            }
            set
            {
                if (value != null)
                {
                    value.PostureDetected += (obj) =>
                    {
                        clickGestureDetected = true;
                    };
                }

                clickPostureDetector = value;
            }
        }

        public bool DisableGestureClick
        {
            get;
            set;
        }
        #endregion

        #region Ctor
        MouseController()
        {
            TrendSmoothingFactor = 0.25f;
            JitterRadius = 0.05f;
            DataSmoothingFactor = 0.5f;
            PredictionFactor = 0.5f;

            GlobalSmooth = 0.9f;
        }
        #endregion

        public void SetHandPosition(KinectSensor sensor, Joint joint, Skeleton skeleton)
        {
            Vector2 vector2 = FilterJointPosition(sensor, joint);

            if (!lastKnownPosition.HasValue)
            {
                lastKnownPosition = vector2;
                previousDepth = joint.Position.Z;
                return;
            }

            bool isClicked = false;

            if (DisableGestureClick)
            {
            }
            else
            {
                if (ClickGestureDetector == null)
                    isClicked = Math.Abs(joint.Position.Z - previousDepth) > 0.05f;
                else
                    isClicked = clickGestureDetected;
            }                    

                MouseInterop.ControlMouse((int)((vector2.X - lastKnownPosition.Value.X) * Screen.PrimaryScreen.Bounds.Width * GlobalSmooth), (int)((vector2.Y - lastKnownPosition.Value.Y) * Screen.PrimaryScreen.Bounds.Height * GlobalSmooth), isClicked);
                lastKnownPosition = vector2;

            previousDepth = joint.Position.Z;

            clickGestureDetected = false;
        }

        Vector2 FilterJointPosition(KinectSensor sensor, Joint joint)
        {
            Vector2 filteredJointPosition;
            Vector2 differenceVector;
            Vector2 currentTrend;
            float distance;

            Vector2 baseJointPosition = Tools.Convert(sensor, joint.Position);
            Vector2 prevFilteredJointPosition = savedFilteredJointPosition;
            Vector2 previousTrend = savedTrend;
            Vector2 previousBaseJointPosition = savedBasePosition;

            // Checking frames count
            switch (frameCount)
            {
                case 0:
                    filteredJointPosition = baseJointPosition;
                    currentTrend = Vector2.Zero;
                    break;
                case 1:
                    filteredJointPosition = (baseJointPosition + previousBaseJointPosition) * 0.5f;
                    differenceVector = filteredJointPosition - prevFilteredJointPosition;
                    currentTrend = differenceVector * TrendSmoothingFactor + previousTrend * (1.0f - TrendSmoothingFactor);
                    break;
                default:
                    // Jitter filter
                    differenceVector = baseJointPosition - prevFilteredJointPosition;
                    distance = Math.Abs(differenceVector.Length);

                    if (distance <= JitterRadius)
                    {
                        filteredJointPosition = baseJointPosition * (distance / JitterRadius) + prevFilteredJointPosition * (1.0f - (distance / JitterRadius));
                    }
                    else
                    {
                        filteredJointPosition = baseJointPosition;
                    }

                    // Double exponential smoothing filter
                    filteredJointPosition = filteredJointPosition * (1.0f - DataSmoothingFactor) + (prevFilteredJointPosition + previousTrend) * DataSmoothingFactor;

                    differenceVector = filteredJointPosition - prevFilteredJointPosition;
                    currentTrend = differenceVector * TrendSmoothingFactor + previousTrend * (1.0f - TrendSmoothingFactor);
                    break;
            }

            // Compute potential new position
            Vector2 potentialNewPosition = filteredJointPosition + currentTrend * PredictionFactor;

            // Cache current value
            savedBasePosition = baseJointPosition;
            savedFilteredJointPosition = filteredJointPosition;
            savedTrend = currentTrend;
            frameCount++;

            return potentialNewPosition;
        }
    }
}