using UnityEngine;

public class BirdAnimationManager : MonoBehaviour
{
    [SerializeField] Animator animator; 

    [SerializeField] AudioSource birdAudio;




    private void Update()
    {
        if (birdAudio.isPlaying)
        {
            animator.SetBool("isTalking", true);
        }
    }

}
