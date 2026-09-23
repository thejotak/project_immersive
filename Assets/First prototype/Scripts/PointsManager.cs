using UnityEngine;
using UnityEngine.Events;

public class PointsManager : MonoBehaviour
{
    public delegate void PlayerPointsChanged(int newAmount);
    public PlayerPointsChanged playerAPointsChanged;
    public PlayerPointsChanged playerBPointsChanged;

    private int playerAPoints = 0;
    public int PlayerAPoints { 
        get { return playerAPoints; }
        set 
        { 
            playerAPoints = value;
            playerAPointsChanged?.Invoke(playerAPoints);
        } 
    }

    private int playerBPoints = 0;
    public int PlayerBPoints
    {
        get { return playerBPoints; }
        set
        {
            playerBPoints = value;
            playerBPointsChanged?.Invoke(playerBPoints);

        }
    }

    [SerializeField] PopupController popupController;
    private PointsDisplay pointsDisplay;


    private void Start()
    {
        pointsDisplay = GetComponentInChildren<PointsDisplay>();
        playerAPointsChanged += pointsDisplay.UpdatePointsText_pA;
        playerBPointsChanged += pointsDisplay.UpdatePointsText_pB;
    }


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
            PlayerAPoints += points;
            print($"{points} points were added to player {player}");
            print($"player {player} now has {PlayerAPoints} points");

            popupController.addPoints(points, player == "A");
        }
        else if (player == "B")
        {
            PlayerBPoints += points;
            print($"{points} points were added to player {player}");
            print($"player {player} now has {PlayerBPoints} points");

            popupController.addPoints(points, player == "A");

        }
    }

}
