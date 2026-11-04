using Mediapipe.Tasks.Vision.PoseLandmarker;
using UnityEngine;

public class FlapManager : MonoBehaviour
{
    float highestElbowValue = -10000f;
    float lowestElbowValue = 10000f;

    int amountOfDirectionChanges = 0;

    [SerializeField] int previousElbowDirection = 0;

    float previousElbowDiff = 0;
    float previousPreviousElbowDiff = 0;

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
        //print("restuarting timer");
        var oldT = t;
        t = 0;
        isTimerRunning = true;
        return oldT;
    }



    public float MeasureFlappingInput(PoseLandmarkerResult result, int player, int landmark)
    {
        Mediapipe.Tasks.Components.Containers.Landmark elbowPos = result.poseWorldLandmarks[player].landmarks[landmark];



        float score = 0;

        // Store highest and lowest elbow value
        if (elbowPos.y > highestElbowValue) highestElbowValue = elbowPos.y;
        if (elbowPos.y < lowestElbowValue) lowestElbowValue = elbowPos.y;


        // determine if the flap has ended 
        if (HasDirectionChanged(elbowPos.y, elbowPosPrevious.y))
        {
            //print("------direction changed--------");
            amountOfDirectionChanges++;
            if (amountOfDirectionChanges == 2)
            {
                score = CalculateFlapScore(highestElbowValue, lowestElbowValue, RestartTimer());

                // A NEW FLAP IS STARTING
                // Reset values for new flap
                highestElbowValue = -10000f;
                lowestElbowValue = 10000f;
                amountOfDirectionChanges = 0;
            }
        }
        //hasDirectionChanged = HasDirectionChanged(elbowPos.y, elbowPosPrevious.y);

        elbowPosPrevious = elbowPos;

        //totalScore += score;
        //currentScore = score;

        return score;
    }

    // Determine change in elbow direction
    private bool HasDirectionChanged(float elbowPosY, float elbowPosPreviousY)
    {
        float elbowDiff = Mathf.Round((elbowPosY - elbowPosPreviousY) * 100) / 10;
        float aggregatedElbowDiff = elbowDiff + previousElbowDiff + previousPreviousElbowDiff;
        //print(aggregatedElbowDiff);
        if (aggregatedElbowDiff > 0.3f)
        {
            if (previousElbowDirection == 1)
            {
                previousElbowDirection = 1;

                previousPreviousElbowDiff = previousElbowDiff;
                previousElbowDiff = elbowDiff;

                return false;
            }
            else
            {
                previousElbowDirection = 1;

                previousPreviousElbowDiff = previousElbowDiff;
                previousElbowDiff = elbowDiff;

                return true;
            }
        }
        else if (aggregatedElbowDiff < -0.3)
        {
            if (previousElbowDirection == -1)
            {
                previousElbowDirection = -1;

                previousPreviousElbowDiff = previousElbowDiff;
                previousElbowDiff = elbowDiff;

                return false;
            }
            else
            {
                previousElbowDirection = -1;

                previousPreviousElbowDiff = previousElbowDiff;
                previousElbowDiff = elbowDiff;

                return true;
            }
        }
        else
        {
            previousPreviousElbowDiff = previousElbowDiff;
            previousElbowDiff = elbowDiff;

            return false;
        }
    }


    private float CalculateFlapScore(float highestElbowValue, float lowestElbowValue, float time)
    {
        float score = 0;

        score = (highestElbowValue - lowestElbowValue);

        return score;
    }
}
