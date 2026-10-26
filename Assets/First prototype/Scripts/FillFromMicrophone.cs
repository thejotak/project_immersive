using UnityEngine;
using UnityEngine.UI;

public class FillFromMicrophone : MonoBehaviour
{
    public Image audioBar;
    public Slider sensitivitySlider;
    public AudioLoudnessDetector detector;

    public float minimumSensibility = 100;
    public float maximumSensibility = 1000;
    public float currentLoudnessSensibility = 500;
    public float threshold = 0.1f;

    // Score
    public ZingManager scoreManager;

    // Threshold voor het krijgen van punten
    public float screamThreshold = 0.8f;

    // Punten voor iedere keer dat de threshold overschreden wordt
    public int pointsPerScream = 10;

    // Houdt bij of we al boven de threshold zitten
    private bool aboveThreshold = false;


    private void Start()
    {
        if (sensitivitySlider == null) return;

        sensitivitySlider.value = .5f;
        SetLoudnessSensibility(sensitivitySlider.value);
    }


    private void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone()
                         * currentLoudnessSensibility;

        Debug.Log(loudness);

        if (loudness < threshold)
        {
            loudness = 0.01f;
        }

        audioBar.fillAmount = loudness;


        // -------------------------
        // SCREAM DETECTION
        // -------------------------

        if (loudness >= screamThreshold)
        {
            // We zijn net van ONDER naar BOVEN
            // de threshold gegaan.
            if (!aboveThreshold)
            {
                scoreManager.AddScore(pointsPerScream);

                Debug.Log(
                    "Threshold gehaald! +"
                    + pointsPerScream
                    + " punten"
                );

                aboveThreshold = true;
            }
        }
        else
        {
            // We zijn weer onder de threshold.
            // De volgende scream mag weer punten geven.
            aboveThreshold = false;
        }
    }


    public void SetLoudnessSensibility(float t)
    {
        currentLoudnessSensibility =
            Mathf.Lerp(
                minimumSensibility,
                maximumSensibility,
                t
            );
    }
}
