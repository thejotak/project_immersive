using System.Collections;
using UnityEngine;
using TMPro;

public class ZingManager : MonoBehaviour
{
    public bool player1Active = true;
    public bool roundActive = true;

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


    void Start()
    {
        StartCoroutine(RoundTimer());
    }


    IEnumerator RoundTimer()
    {
        // -------------------------
        // PLAYER A - 30 SECONDEN
        // -------------------------

        player1Active = true;

        // Zet audio bar aan de kant van Player A
        audioBar.anchoredPosition = playerABarPosition;

        float timer = switchTime;

        while (timer > 0)
        {
            timerText.text = Mathf.CeilToInt(timer).ToString();

            timer -= Time.deltaTime;

            yield return null;
        }


        // -------------------------
        // PLAYER B - 30 SECONDEN
        // -------------------------

        player1Active = false;

        // Verplaats audio bar naar de kant van Player B
        audioBar.anchoredPosition = playerBBarPosition;

        timer = switchTime;

        while (timer > 0)
        {
            timerText.text = Mathf.CeilToInt(timer).ToString();

            timer -= Time.deltaTime;

            yield return null;
        }


        // -------------------------
        // RONDE AFGELOPEN
        // -------------------------

        timerText.text = "0";

        roundActive = false;

        Debug.Log("Ronde afgelopen!");
    }


    public void AddScore(int amount)
    {
        // Geen punten meer nadat beide spelers
        // hun ronde hebben gehad
        if (!roundActive)
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