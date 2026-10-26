using Mediapipe.Tasks.Vision.PoseLandmarker;
using Mediapipe.Unity.Sample.PoseLandmarkDetection;
using UnityEngine;

public class FlappingCoordinator : MonoBehaviour
{
    PoseLandmarkerRunner runner;
    MeasureFlapQuality[] MeasureFlapQualities;

    [SerializeField] PointsManager pointsManager;

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
        string[] players = new string[2];
        players[0] = "B";
        players[1] = "A";

        // The output score is somewhere between 0.2 and 0.6, so for a score between 3 and 10 we do points = (score * 100/7).RoundToInt
        // 0.2 => 3 and 0.6 => 9, so there is some room for excellence

        int points = Mathf.RoundToInt(score * 100 / 6);

        pointsManager.AddPoints(points, players[player]);

        //print("----------");
        //print($"player {player} got {points} points");
    }

}
