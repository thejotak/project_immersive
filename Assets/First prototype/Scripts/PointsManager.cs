using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public int playerAPoints = 0;
    public int playerBPoints = 0;

    [SerializeField] PopupController popupController;


    // Update is called once per frame
    void Update()
    {
        DebugPointsInput();
    }


    private void DebugPointsInput()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            
            if (Input.GetKeyDown(KeyCode.A))
            {
                AddPoints(10, "A");
            } else if (Input.GetKeyDown(KeyCode.B))
            {
                AddPoints(10, "B");
            }
        }

        else if (Input.GetKey(KeyCode.Alpha2))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                AddPoints(20, "A");
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                AddPoints(20, "B");
            }
        }

        else if (Input.GetKey(KeyCode.Alpha3))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                AddPoints(30, "A");
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                AddPoints(30, "B");
            }
        }

        else return;
    }

    private void AddPoints(int points, string player)
    {
        if (player == "A")
        {
            playerAPoints += points;
            print($"{points} points were added to player {player}");
            print($"player {player} now has {playerAPoints} points");

            popupController.addPoints(points);
        }
        else if (player == "B")
        {
            playerBPoints += points;
            print($"{points} points were added to player {player}");
            print($"player {player} now has {playerBPoints} points");

            popupController.addPoints(points);

        }
    }

}
