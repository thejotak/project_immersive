using UnityEngine;

public class GameManager : MonoBehaviour
{
    WinScreen winScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winScreen = GetComponentInChildren<WinScreen>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForGameEnd();
    }


    private void CheckForGameEnd()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                print(" Player A wins!");
                winScreen.PlayerAWins();
            } 
            else if (Input.GetKeyDown(KeyCode.B))
            {
                print(" Player B wins!");
                winScreen.PlayerBWins();
            }
        }
    }
}
