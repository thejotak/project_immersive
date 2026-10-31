using UnityEngine;

public class PopupObject : MonoBehaviour
{
    [SerializeField] float spd;
    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 moveDir;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(moveDir * Time.deltaTime * spd);
    }
}
