using UnityEngine;

public class BeatPulse : MonoBehaviour
{
    [SerializeField] private float bpm = 120f;
    [SerializeField] private float firstBeatOffset = 0f;  // seconds until the first beat in the song
    [SerializeField] private float pulseScale = 1.2f;     // 1.2 = 20% bigger on the beat
    [SerializeField] private float returnSpeed = 6f;      // higher = shrinks back faster

    private Vector3 originalScale;
    private float startTime;
    private int lastBeat = -1;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        float secondsPerBeat = 60f / bpm;
        float songTime = Time.time - startTime;
        int currentBeat = Mathf.FloorToInt((songTime - firstBeatOffset) / secondsPerBeat);

        // a new beat has started
        if (currentBeat != lastBeat)
        {
            lastBeat = currentBeat;
            transform.localScale = originalScale * pulseScale; // instant grow
        }

        // slowly shrink back to the original size
        transform.localScale = Vector3.Lerp(
            transform.localScale,
            originalScale,
            returnSpeed * Time.deltaTime);
    }
}


//Dit script heb ik niet gemaakt, het werkt ook niet zoals gewilt en wil ik dus ook nog zelf maken maar het is op dit moment
//van tijd niet mogelijk, sorry hiervoor