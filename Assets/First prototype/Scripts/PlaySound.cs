using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [Header("------Audio Source------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource BirdSource;

    [Header("------Audio Clip------")]
    public AudioClip Intro;
    public AudioClip Goodflap;
    public AudioClip Badflap1;
    public AudioClip Badflap2;
    public AudioClip Badflap3;
    public AudioClip Flamingofetisch;
    public AudioClip Goodflamingo;
    public AudioClip Badflamingo;
    public AudioClip Sing4baby;
    public AudioClip Singgood;
    public AudioClip Singgoodgood;
    public AudioClip Singgoodbad;
    public AudioClip Singbadgood;
    public AudioClip Singbadbad;
    public AudioClip nostop1;
    public AudioClip nostop2;
    public AudioClip Fight;
    public AudioClip Nofight;
    public AudioClip Catcall1;
    public AudioClip Catcall2;
  

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            BirdSource.PlayOneShot(Intro);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            BirdSource.PlayOneShot(Goodflap);

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            BirdSource.PlayOneShot(Badflap1);

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            BirdSource.PlayOneShot(Badflap2);

        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            BirdSource.PlayOneShot(Badflap3);

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            BirdSource.PlayOneShot(Catcall1);

        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            BirdSource.PlayOneShot(Catcall2);

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            BirdSource.PlayOneShot(nostop1);

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            BirdSource.PlayOneShot(nostop2);

        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            BirdSource.PlayOneShot(Flamingofetisch);

        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            BirdSource.PlayOneShot(Goodflamingo);

        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            BirdSource.PlayOneShot(Badflamingo);

        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            BirdSource.PlayOneShot(Fight);

        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            BirdSource.PlayOneShot(Nofight);

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            BirdSource.PlayOneShot(Sing4baby);

        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            BirdSource.PlayOneShot(Singgood);

        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            BirdSource.PlayOneShot(Singgoodbad);

        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            BirdSource.PlayOneShot(Singgoodgood);

        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            BirdSource.PlayOneShot(Singbadbad);

        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            BirdSource.PlayOneShot(Singbadgood);

        }
    }
}
