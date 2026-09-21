using UnityEngine;
using System.Collections.Generic;

public class PopupController : MonoBehaviour
{
    [SerializeField] List<Material> popupMaterials;
    [SerializeField] GameObject popupPrefab;
    [SerializeField] float lifeSpan;

    public void addPoints(int ptAmount)
    {
        // quick fix
        ptAmount /= 10;
        ptAmount -= 1;


        for (int i = 0; i<popupMaterials.Count; i++)
        {
            if (i == ptAmount)
                createPopup(popupMaterials[i]);
        }
    }
    
    private void createPopup(Material popupMat)
    {
        popupMat.SetFloat("_CurrentTime", Time.time);
        GameObject popup = Instantiate(popupPrefab);

        popup.GetComponent<MeshRenderer>().material = popupMat;
        Destroy(popup, lifeSpan);
    }
}
