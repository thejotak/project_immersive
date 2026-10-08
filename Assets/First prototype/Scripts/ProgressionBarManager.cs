using UnityEngine;
using System.Collections;

public class ProgressionBarManager : MonoBehaviour
{
    public PointsManager pointsManager;
    [SerializeField] private Material sliderMat;
    [SerializeField] private string sliderDistributionFloatName;
    [SerializeField] private int maxScore;
    private float a0;
    private float b0;
    public void Start()
    {
        sliderMat.SetFloat(sliderDistributionFloatName, 0f);
        distribution0 = 0;
        a0 = 0;
        b0 = 0;
        pointsManager.playerAPointsChanged += updateProgressionBar;
        pointsManager.playerBPointsChanged += updateProgressionBar;
    }

    private float distribution0;
    private void updateProgressionBar(int i)
    {
        float a = pointsManager.PlayerAPoints;
        float b = pointsManager.PlayerBPoints;
        float distribution = distribution0 + ((a-a0)/maxScore) - ((b-b0)/maxScore);

        StartCoroutine(changeValueOverTime(distribution0, distribution, 0.5f));

        a0 = a;
        b0 = b;
        distribution0 = distribution;
    }

    IEnumerator changeValueOverTime(float fromVal, float toVal, float duration)
    {
        float counter = 0f;

        while (counter < duration)
        {
            if (Time.timeScale == 0)
                counter += Time.unscaledDeltaTime;
            else
                counter += Time.deltaTime;

            float val = Mathf.Lerp(fromVal, toVal, counter / duration);
            Debug.Log("Val: " + val);
            sliderMat.SetFloat(sliderDistributionFloatName, val);
            yield return null;
        }
    }
    float Lerp(float firstFloat, float secondFloat, float by)
    {
        return firstFloat * (1 - by) + secondFloat * by;
    }
}
