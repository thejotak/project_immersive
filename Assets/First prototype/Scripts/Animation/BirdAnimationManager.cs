using UnityEngine;

public class BirdAnimationManager : MonoBehaviour
{
    [SerializeField] Animator animator; 

    [SerializeField] AudioSource birdAudio;


    [SerializeField] bool isLeanLerping = false;
    float targetDistibution;
    float t;
    float lerpSpeed = 1;

    public void Lean(float distribution)
    {
        distribution *= -1;
        distribution += 0.5f;
        targetDistibution = distribution;
        t = 0;
        isLeanLerping = true;
        
    }

    private void Update()
    {
        if (birdAudio.isPlaying)
        {
            animator.SetBool("isTalking", true);
        }

        if (isLeanLerping)
        {
            t += Time.deltaTime;
            float distribution = animator.GetFloat("idleBlend") + (targetDistibution - animator.GetFloat("idleBlend"))/lerpSpeed * Time.deltaTime;

            animator.SetFloat("idleBlend", distribution);
        }
    }

    public void BeSilent()
    {
        animator.SetTrigger("shush");
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
