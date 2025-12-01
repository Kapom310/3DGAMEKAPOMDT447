using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgmAudioSource; // Reference to the AudioSource component
    [SerializeField] private float startTime = 0f; // Time in seconds to start the BGM

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the AudioSource component is assigned
        if (bgmAudioSource == null)
        {
            Debug.LogError("BGM AudioSource is not assigned!");
            return;
        }

        // Set the start time of the BGM
        if (startTime >= 0 && startTime < bgmAudioSource.clip.length)
        {
            bgmAudioSource.time = startTime;
            bgmAudioSource.Play();
            
        }
        else
        {
            Debug.LogWarning("Invalid start time for BGM. Using default start time (0 seconds).");
            bgmAudioSource.Play();
        }
    }

    private void Update()
    {
        //Debug.Log(bgmAudioSource.time);
    }
}