using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    [Header("Algemene gametimer")]
    [SerializeField] private float time_Left = 180f;

    [Header("Victory schermen")]
    [SerializeField] private string blueVictoryScreen;
    [SerializeField] private string redVictoryScreen;

    [Header("Zing Stage")]
    [SerializeField] private ZingManager zingManager;

    // Zing begint na 2 minuten
    [SerializeField] private float zingStartTime = 120f;

    // Houdt bij hoeveel tijd verstreken is
    private float elapsedTime = 0f;

    // Zorgt dat Zing maar één keer gestart wordt
    private bool zingStarted = false;


    private void Start()
    {
        StartCoroutine(TimerCount());
    }


    private IEnumerator TimerCount()
    {
        while (time_Left > 0f)
        {
            yield return new WaitForSeconds(1f);

            time_Left -= 1f;
            elapsedTime += 1f;

            UpdateTimer();

            // Na 120 seconden wordt de Zing-stage gestart
            if (elapsedTime >= zingStartTime && !zingStarted)
            {
                zingStarted = true;

                if (zingManager != null)
                {
                    zingManager.StartZingStage();
                }
                else
                {
                    Debug.LogWarning(
                        "ZingManager is niet ingevuld in TimerScript!"
                    );
                }
            }
        }

        time_Left = 0f;
        UpdateTimer();

        Debug.Log("Time's UP!");

        SceneManager.LoadScene(DetermineWinScreen());
    }


    private string DetermineWinScreen()
    {
        if (PointsManager.instance.PlayerAPoints >
            PointsManager.instance.PlayerBPoints)
        {
            return redVictoryScreen;
        }
        else
        {
            return blueVictoryScreen;
        }
    }


    private void UpdateTimer()
    {
        int min = Mathf.FloorToInt(time_Left / 60f);

        // Dit was eerst opnieuw / 60.
        // Met % 60 krijg je de overgebleven seconden.
        int sec = Mathf.FloorToInt(time_Left % 60f);

        //Debug.Log(
        //    "Algemene tijd: "
        //    + min.ToString("00")
        //    + ":"
        //    + sec.ToString("00")
        //);
    }
}