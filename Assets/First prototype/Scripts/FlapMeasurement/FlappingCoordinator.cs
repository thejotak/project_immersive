using Mediapipe.Tasks.Vision.PoseLandmarker;
using Mediapipe.Unity.Sample.PoseLandmarkDetection;
using UnityEngine;

public class FlappingCoordinator : MonoBehaviour
{
    PoseLandmarkerRunner runner;
    MeasureFlapQuality[] MeasureFlapQualities;

    private void Start()
    {
        runner = GetComponent<PoseLandmarkerRunner>();
        runner.onPoseLandmarkerResult += MeasureFlaps;

        MeasureFlapQualities = GetComponentsInChildren<MeasureFlapQuality>();
    }


    private void MeasureFlaps(PoseLandmarkerResult result)
    {
        for (int i = 0; i < MeasureFlapQualities.Length; i++)
        {
            MeasureFlapQualities[i].StartFlapMeasument(result, i);

            MeasureFlapQualities[i].returnFlapScore -= HandleScores;
            MeasureFlapQualities[i].returnFlapScore += HandleScores;
        }
    }

    private void HandleScores(float score, int player)
    {
        print("----------");
        print($"player {player} got a score of {score}");
    }

}
