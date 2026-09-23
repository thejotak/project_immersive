using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject AWinText;
    [SerializeField] GameObject BWinText;




    public void PlayerAWins()
    {
        panel.SetActive(true);
        AWinText.SetActive(true);
    }

    public void PlayerBWins()
    {
        panel.SetActive(true);
        BWinText.SetActive(true);
    }
}
