using TMPro;
using UnityEngine;

public class PointsPopupController : MonoBehaviour
{
    [SerializeField] GameObject popupPrefab;
    [SerializeField] float lifeSpan;

    [SerializeField] Transform posA;
    [SerializeField] Transform posB;

    

    public void CreatePopup(int ptAmount, bool isPosA)
    {
        Transform pos;
        if (isPosA) pos = posA;
        else pos = posB;

        GameObject popup = Instantiate(popupPrefab, Vector3.zero, Quaternion.identity, pos);
        popup.transform.position = pos.position;
        popup.GetComponent<TextMeshProUGUI>().text = $"+ {ptAmount}";
        Destroy(popup, lifeSpan);
    }
}
