using UnityEngine;
using UnityEngine.Events;

public class PointsManager : MonoBehaviour
{
    public static PointsManager instance;

    public delegate void PlayerPointsChanged(int newAmount);
    public PlayerPointsChanged playerAPointsChanged;
    public PlayerPointsChanged playerBPointsChanged;

    public GameManager gameManager;

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
            AddPoints(10, "A");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AddPoints(10, "B");
        }
    }

    public void AddPoints(int points, string player)
    {
        if (player == "A")
        {
            PlayerAPoints += points;
            print($"{points} points were added to player {player}");
            print($"player {player} now has {PlayerAPoints} points");

            if (gameManager.isP0Flamingo) points *= 2;

            pointsPopupController.CreatePopup(points, player == "A");
        }
        else if (player == "B")
        {
            PlayerBPoints += points;
            print($"{points} points were added to player {player}");
            print($"player {player} now has {PlayerBPoints} points");

            if (gameManager.isP1Flamingo) points *= 2;


            pointsPopupController.CreatePopup(points, player == "A");

        }
    }

}
