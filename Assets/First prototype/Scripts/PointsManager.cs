using UnityEngine;
using UnityEngine.Events;

public class PointsManager : MonoBehaviour
{
    public static PointsManager instance;

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

    [SerializeField] PointsPopupController pointsPopupController;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        DebugPointsInput();
    }


    private void DebugPointsInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddPoints(10, "B");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AddPoints(10, "A");
        }
    }

    public void AddPoints(int points, string player)
    {
        if (player == "A")
        {
            PlayerAPoints += points;
            print($"{points} points were added to player {player}");
            print($"player {player} now has {PlayerAPoints} points");

            pointsPopupController.CreatePopup(points, player == "A");
        }
        else if (player == "B")
        {
            PlayerBPoints += points;
            print($"{points} points were added to player {player}");
            print($"player {player} now has {PlayerBPoints} points");

            pointsPopupController.CreatePopup(points, player == "A");

        }
    }

}
