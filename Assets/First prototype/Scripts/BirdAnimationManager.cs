using UnityEngine;

public class BirdAnimationManager : MonoBehaviour
{
    [SerializeField] Animator animator; 

    [SerializeField] AudioSource birdAudio;


    public void Lean(float distribution)
    {
        distribution += 0.5f;

        animator.SetFloat("idleBlend", distribution);
    }

    private void Update()
    {
        if (birdAudio.isPlaying)
        {
            animator.SetBool("isTalking", true);
        }
    }


    public void ContinueFlapping()
    {
        animator.SetTrigger("flutter");
    }

    public void ListenRight()
    {
        animator.SetBool("listenL", false);
        animator.SetBool("listenR", true);
    }

    public void ListenLeft()
    {
        animator.SetBool("listenR", false);
        animator.SetBool("listenL", true);
    }
    

    public void StopListening()
    {
        animator.SetBool("listenR", false);
        animator.SetBool("listenL", false);
    }


}
