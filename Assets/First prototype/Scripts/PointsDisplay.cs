using TMPro;
using UnityEngine;

public class PointsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsTextA;
    [SerializeField] private TextMeshProUGUI pointsTextB;

    public void UpdatePointsText_pA(int newAmount)
    {
        pointsTextA.text = newAmount.ToString();
    }


    public void UpdatePointsText_pB(int newAmount)
    {
        pointsTextB.text = newAmount.ToString();
    }


}
