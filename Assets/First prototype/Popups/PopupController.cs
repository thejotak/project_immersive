using UnityEngine;
using System.Collections.Generic;

public class PopupController : MonoBehaviour
{
    [SerializeField] List<Material> popupMaterials;
    [SerializeField] GameObject popupPrefab;
    [SerializeField] float lifeSpan;

    [SerializeField] Vector2 posA;
    [SerializeField] Vector2 posB;

    public void addPoints(int ptAmount, bool isPosA)
    {
        // quick fix
        ptAmount /= 10;
        ptAmount -= 1;

        Vector2 pos;
        if (isPosA) pos = posA;
        else pos = posB;


        for (int i = 0; i<popupMaterials.Count; i++)
        {
            if (i == ptAmount)
                createPopup(popupMaterials[i], pos);
        }
    }
    
    private void createPopup(Material popupMat, Vector2 pos)
    {
        popupMat.SetFloat("_CurrentTime", Time.time);
        GameObject popup = Instantiate(popupPrefab, pos, Quaternion.identity);
        Debug.Log(popup.transform.position);

        popup.GetComponent<MeshRenderer>().material = popupMat;
        Destroy(popup, lifeSpan);
    }
}
