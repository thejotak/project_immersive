using System.Collections;
using UnityEngine;
using TMPro;

public class ZingManager : MonoBehaviour
{
    public bool player1Active = true;

    // De ronde is aan het begin nog niet actief
    public bool roundActive = false;

    // Geeft aan of de Zing-stage gestart is
    public bool zingStageActive = false;

    // Duur per speler
    public float switchTime = 30f;

    // UI timer
    public TMP_Text timerText;

    // Score
    public PointsManager pointsManager;

    // -------------------------
    // AUDIO BAR
    // -------------------------

    public RectTransform audioBar;

    // Positie voor Player A en Player B
    public Vector2 playerABarPosition;
    public Vector2 playerBBarPosition;

    private Coroutine roundCoroutine;


    private void Start()
    {
        // De Zing-stage begint nog niet direct.
        zingStageActive = false;
        roundActive = false;

        // Timer staat op 0 totdat de Zing-stage begint
        if (timerText != null)
        {
            timerText.text = "0";
        }

        // De audio bar eventueel verbergen tot de stage begint
        if (audioBar != null)
        {
            audioBar.gameObject.SetActive(false);
        }
    }


    public void StartZingStage()
    {
        // Voorkomt dat de stage meerdere keren gestart wordt
        if (zingStageActive)
        {
            return;
        }

        Debug.Log("2 minuten voorbij: Zing-stage gestart!");

        zingStageActive = true;
        roundActive = true;
        player1Active = true;

        // Audio bar zichtbaar maken
        if (audioBar != null)
        {
            audioBar.gameObject.SetActive(true);
            audioBar.anchoredPosition = playerABarPosition;
        }

        // Start de rondes
        roundCoroutine = StartCoroutine(RoundTimer());
    }


    private IEnumerator RoundTimer()
    {
        // -------------------------
        // PLAYER A - 30 SECONDEN
        // -------------------------

        player1Active = true;

        if (audioBar != null)
        {
            audioBar.anchoredPosition = playerABarPosition;
        }

        Debug.Log("Ronde van speler A gestart!");

        float timer = switchTime;

        while (timer > 0f)
        {
            if (timerText != null)
            {
                timerText.text = Mathf.CeilToInt(timer).ToString();
            }

            timer -= Time.deltaTime;

            yield return null;
        }


        // -------------------------
        // PLAYER B - 30 SECONDEN
        // -------------------------

        player1Active = false;

        if (audioBar != null)
        {
            audioBar.anchoredPosition = playerBBarPosition;
        }

        Debug.Log("Ronde van speler B gestart!");

        timer = switchTime;

        while (timer > 0f)
        {
            if (timerText != null)
            {
                timerText.text = Mathf.CeilToInt(timer).ToString();
            }

            timer -= Time.deltaTime;

            yield return null;
        }


        // -------------------------
        // RONDE AFGELOPEN
        // -------------------------

        if (timerText != null)
        {
            timerText.text = "0";
        }

        // Audio bar verbergen na speler B
        if (audioBar != null)
        {
            audioBar.gameObject.SetActive(false);
        }

        roundActive = false;
        zingStageActive = false;
        roundCoroutine = null;

        Debug.Log("Zing-rondes afgelopen!");
    }


    public void AddScore(int amount)
    {
        // Geen punten geven als de Zing-stage niet actief is
        if (!zingStageActive || !roundActive)
        {
            return;
        }

        // Player A is bezig
        if (player1Active)
        {
            pointsManager.AddPoints(amount, "A");
        }
        // Player B is bezig
        else
        {
            pointsManager.AddPoints(amount, "B");
        }
    }
}