using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject obj_PopupController;
    PopupController popupController;
    void Start()
    {
        popupController = obj_PopupController.GetComponent<PopupController>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            popupController.addPoints(1);
            Debug.Log("space down");
        }
    }
}
