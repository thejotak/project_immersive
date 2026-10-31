using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TimerScript : MonoBehaviour
{
    [SerializeField] private float time_Left;

    [SerializeField] private string blueVictoryScreen;
    [SerializeField] private string redVictoryScreen;


  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(timer_Count());
    }

    IEnumerator timer_Count()
    {
        time_Left--;

        UpdateTimer();

        if(time_Left <= 0)
        {
            SceneManager.LoadScene(DetermineWinScreen());
            Debug.Log("Time's UP!");
            time_Left = 0;
            StopAllCoroutines();
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(timer_Count());
    }

    private string DetermineWinScreen()
    {
        if (PointsManager.instance.PlayerAPoints > PointsManager.instance.PlayerBPoints)
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
        int min = Mathf.FloorToInt(time_Left / 60);
        int sec = Mathf.FloorToInt(time_Left / 60);
    }
}
