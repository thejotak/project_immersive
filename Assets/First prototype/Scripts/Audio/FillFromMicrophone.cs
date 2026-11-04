using UnityEngine;
using UnityEngine.UI;

public class FillFromMicrophone : MonoBehaviour
{
    public Image audioBar;
    public Slider sensitivitySlider;
    public AudioLoudnessDetector detector;

    public float minimumSensibility = 100f;
    public float maximumSensibility = 1000f;
    public float currentLoudnessSensibility = 500f;
    public float threshold = 0.1f;

    // Score en Zing-status
    public ZingManager scoreManager;

    // Threshold voor het krijgen van punten
    public float screamThreshold = 0.8f;

    // Punten voor iedere keer dat de threshold overschreden wordt
    public int pointsPerScream = 2;

    // Houdt bij of we al boven de threshold zitten
    private bool aboveThreshold = false;


    private void Start()
    {
        if (sensitivitySlider != null)
        {
            sensitivitySlider.value = 0.5f;
            SetLoudnessSensibility(sensitivitySlider.value);
        }

        if (audioBar != null)
        {
            audioBar.fillAmount = 0f;
        }
    }


    private void Update()
    {
        // Doe nog niets voordat de Zing-stage gestart is.
        if (scoreManager == null ||
            !scoreManager.zingStageActive ||
            !scoreManager.roundActive)
        {
            aboveThreshold = false;

            if (audioBar != null)
            {
                audioBar.fillAmount = 0f;
            }

            return;
        }

        if (detector == null)
        {
            return;
        }

        float loudness =
            detector.GetLoudnessFromMicrophone()
            * currentLoudnessSensibility;

        if (loudness < threshold)
        {
            loudness = 0.01f;
        }

        // Zorgt dat de fillAmount tussen 0 en 1 blijft
        loudness = Mathf.Clamp01(loudness);

        if (audioBar != null)
        {
            audioBar.fillAmount = loudness;
        }


        // -------------------------
        // SCREAM DETECTION
        // -------------------------

        if (loudness >= screamThreshold)
        {
            // We zijn net van onder naar boven
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
            // Eerst weer onder de threshold komen
            // voordat een nieuwe scream punten geeft.
            aboveThreshold = false;
        }
    }


    public void SetLoudnessSensibility(float t)
    {
        currentLoudnessSensibility = Mathf.Lerp(minimumSensibility,maximumSensibility,t);
    }
}