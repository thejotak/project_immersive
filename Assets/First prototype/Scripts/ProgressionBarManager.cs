using UnityEngine;
using System.Collections;

public class ProgressionBarManager : MonoBehaviour
{
    public PointsManager pointsManager;
    [SerializeField] private Material sliderMat;
    [SerializeField] private string sliderDistributionFloatName;
    [SerializeField] private int maxScore;
    [SerializeField] private BirdAnimationManager animationManager;
    private float a0;
    private float b0;
    public GameObject SadBlueBird;
    public GameObject SadRedBird;
    public GameObject NeutralBlueBird;
    public GameObject NeutralRedBird;
    public GameObject NeutralLoveBird;
    public GameObject LeftLoveBird;
    public GameObject RightLoveBird;
    public void Start()
    {
        sliderMat.SetFloat(sliderDistributionFloatName, 0f);
        distribution0 = 0;
        a0 = 0;
        b0 = 0;
        pointsManager.playerAPointsChanged += updateProgressionBar;
        pointsManager.playerBPointsChanged += updateProgressionBar;

       
        NeutralBlueBird.SetActive(true);
        NeutralRedBird.SetActive(true);
        NeutralLoveBird.SetActive(true);

        SadBlueBird.SetActive(false);
        SadRedBird.SetActive(false);
        LeftLoveBird.SetActive(false);
        RightLoveBird.SetActive(false);


    }

    private float distribution0;
    private void updateProgressionBar(int i)
    {
        float a = pointsManager.PlayerAPoints;
        float b = pointsManager.PlayerBPoints;
        float distribution = distribution0 + ((a-a0)/maxScore) - ((b-b0)/maxScore);

        animationManager.Lean(distribution);
        StartCoroutine(changeValueOverTime(distribution0, distribution, 0.5f));

        a0 = a;
        b0 = b;
        distribution0 = distribution;

        if (distribution >= 0.2f)

            {
                Debug.Log("Bluebird is sad");
                
                NeutralBlueBird.SetActive(false);
                SadBlueBird.SetActive(true);
                NeutralRedBird.SetActive(true);
                SadRedBird.SetActive(false);
                NeutralLoveBird.SetActive(false);
                LeftLoveBird.SetActive(false);
                RightLoveBird.SetActive(true);
            }
        else if (distribution <= -0.2f) 
            {
                Debug.Log("Redbird is sad");
                SadBlueBird.SetActive(false);
                NeutralBlueBird.SetActive(true);
                NeutralRedBird.SetActive(false);
                SadRedBird.SetActive(true);
                NeutralLoveBird.SetActive(false);
                LeftLoveBird.SetActive(true);
                RightLoveBird.SetActive(false);
            }
        else
        {
                Debug.Log("Both Bitch Birds Neutral");
                SadBlueBird.SetActive(false);
                NeutralBlueBird.SetActive(true);
                NeutralRedBird.SetActive(true);
                SadRedBird.SetActive(false); 
                NeutralLoveBird.SetActive(true);
                LeftLoveBird.SetActive(false);
                RightLoveBird.SetActive(false);
        }
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
            //Debug.Log("Val: " + val);
            sliderMat.SetFloat(sliderDistributionFloatName, val);
            yield return null;
        }
    }
    float Lerp(float firstFloat, float secondFloat, float by)
    {
        return firstFloat * (1 - by) + secondFloat * by;
    }
}
