using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private float waitTime = 2;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoFinished;
            StartCoroutine("Begin");
        }
        else
        {
            Debug.LogError("Geen VideoPlayer component gevonden!");
        }
    }

    private IEnumerator Begin()
    {
        yield return new WaitForSeconds(waitTime);
        videoPlayer.Play();
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(4);
    }
}