using System.Collections;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour

   
{
    public string levelToLoad;
    [SerializeField] private float time_Left;


  

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
            SceneManager.LoadScene("VictoryScreen");
            Debug.Log("Time's UP!");
            time_Left = 0;
            StopAllCoroutines();
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(timer_Count());
    }



    private void UpdateTimer()
    {
        int min = Mathf.FloorToInt(time_Left / 60);
        int sec = Mathf.FloorToInt(time_Left / 60);
    }
}
