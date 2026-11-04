using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool shouldFlaming;

    public bool isP0Flamingo;
    public bool isP1Flamingo;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            isP0Flamingo = !isP0Flamingo;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            isP1Flamingo = !isP1Flamingo;
        }
    }
}
