using Mediapipe;
using Mediapipe.Tasks.Components.Containers;
using Mediapipe.Tasks.Vision.PoseLandmarker;
using UnityEngine;

    public class MeasureFlapQuality : MonoBehaviour
    {
        // Every function needs to account for two players with both two arms



        int previousElbowDirection = 0;

        float highestElbowValue = -10000f;
        float lowestElbowValue = 10000f;

        int amountOfDirectionChanges = 0;


        float t = 0;
        bool isTimerRunning = false;

        Mediapipe.Tasks.Components.Containers.Landmark elbowPosPrevious;

        private void Start()
        {
            elbowPosPrevious = new Mediapipe.Tasks.Components.Containers.Landmark();
        }



        private void Update()
        {
            if (isTimerRunning) t += Time.deltaTime;
        }

        private float RestartTimer()
        {
            print("restuarting timer");
            var oldT = t;
            t = 0;
            isTimerRunning = true;
            return oldT;
        }


        public void MeasureFlappingInput(PoseLandmarkerResult result)
        {
            Mediapipe.Tasks.Components.Containers.Landmark elbowPos = result.poseWorldLandmarks[0].landmarks[13];

            // Store highest and lowest elbow value
            if (elbowPos.y > highestElbowValue) highestElbowValue = elbowPos.y;
            if (elbowPos.y < lowestElbowValue) lowestElbowValue = elbowPos.y;


            // determine if the flap has ended 
            if (HasDirectionChanged(elbowPos.y, elbowPosPrevious.y))
            {
                amountOfDirectionChanges++;
                if (amountOfDirectionChanges == 2)
                {
                    CalculateFlapScore(highestElbowValue, lowestElbowValue, RestartTimer());

                    // A NEW FLAP IS STARTING
                    // Reset values for new flap
                    highestElbowValue = -10000f;
                    lowestElbowValue = 10000f;
                    amountOfDirectionChanges = 0;
                }
            }


            elbowPosPrevious = elbowPos;
        }

        // Determine change in elbow direction
        private bool HasDirectionChanged(float elbowPosY, float elbowPosPreviousY)
        {
            if (elbowPosY - elbowPosPreviousY > 0)
            {
                if (previousElbowDirection == 1)
                {
                    previousElbowDirection = 1;
                    return false;
                }
                else
                {
                    previousElbowDirection = 1;
                    return true;
                }
            }
            else
            {
                if (previousElbowDirection == -1)
                {
                    previousElbowDirection = -1;
                    return false;
                }
                else
                {
                    previousElbowDirection = -1;
                    return true;
                }
            }
        }


        private void CalculateFlapScore(float highestElbowValue, float lowestElbowValue, float time)
        {
            float score = 0;

            score = (highestElbowValue - lowestElbowValue) * time;

            print(score);
        }


    }
