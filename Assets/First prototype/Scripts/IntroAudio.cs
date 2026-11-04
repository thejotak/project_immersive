using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] string nextScene;

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
