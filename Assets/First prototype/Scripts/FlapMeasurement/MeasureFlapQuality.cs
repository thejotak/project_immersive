using Mediapipe.Tasks.Vision.PoseLandmarker;
using UnityEngine;



public class MeasureFlapQuality : MonoBehaviour
{

    [SerializeField] float flapElbowScoreDiffInterval = 0.2f;
    [SerializeField] int player;

    private float t;
    bool isTimerActive;
    bool isWaitingForOtherElbow;

    float leftElbowScore;
    float rightElbowScore;

    float currentFlapLeftElbowScore;
    float currentFlapRightElbowScore;

    public delegate void ReturnFlapScore(float score, int player);
    public ReturnFlapScore returnFlapScore;

    FlapManager[] flapManagers;


        private void Start()
        {
            flapManagers = GetComponentsInChildren<FlapManager>();
            if (flapManagers.Length != 2) Debug.LogError("The flapManager amount is not correct!");
        }

    private void Update()
    {
        if (isTimerActive)
        {
            t += Time.deltaTime;

            if (leftElbowScore > 0) currentFlapLeftElbowScore = leftElbowScore;
            if (rightElbowScore > 0) currentFlapRightElbowScore = rightElbowScore;

            if (currentFlapLeftElbowScore > 0 && currentFlapRightElbowScore > 0)
            {
                DeliverFlapResult(true);
                isTimerActive = false;
            }

            if (t > flapElbowScoreDiffInterval)
            {
                DeliverFlapResult(false);
                isTimerActive = false;
            }
        }
    }

    void StartTimer()
    {
        t = 0;
        isTimerActive = true;
    }


    public void StartFlapMeasument(PoseLandmarkerResult result, int player)
    {
        if (this.player != player) print("player changed?????");
        this.player = player;

        leftElbowScore = flapManagers[0].MeasureFlappingInput(result, player, 14);
        rightElbowScore = flapManagers[1].MeasureFlappingInput(result, player, 13);
        
        if (leftElbowScore > 0 || rightElbowScore > 0 !& isWaitingForOtherElbow)
        {
            currentFlapLeftElbowScore = leftElbowScore;
            currentFlapRightElbowScore = rightElbowScore;


            // Wait for the other elbow to also finish the flap
            StartTimer();
            isWaitingForOtherElbow = true;
        }
    }

    private void DeliverFlapResult(bool syncronous)
    {
        if (syncronous)
        {
            float score = currentFlapRightElbowScore + currentFlapLeftElbowScore;
            returnFlapScore?.Invoke(score, player);

            //print($"Player 1 did a flap with score: {score}");
            //print("------------------");

        } else
        {
            Debug.Log($"[{player}] Arms are not syncronous, no points will be awarded");
        }

        isWaitingForOtherElbow = false;
    }
}

