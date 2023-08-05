using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public AudioSource bgmAudioSource;
    private bool isMusicPaused = false;
    private float savedVolume;
    public GameObject[] objectsToDestroy;
    private static bool musicPersisted = false;

    /*private void Start()
    {
        // Find the AudioSource component on the AudioManager GameObject
        bgmAudioSource = GetComponent<AudioSource>();
        // Play the audio
        if (bgmAudioSource != null && !bgmAudioSource.isPlaying && musicPlaying == false)
        {
            Debug.Log("Music start");
            bgmAudioSource.Play();
        }
    }*/

    private void Awake()
    {
        // Check if the AudioSource is playing the "Curious" clip on the same GameObject.
        if (musicPersisted == false && bgmAudioSource != null && bgmAudioSource.clip.name == "Curious")
        {
            // Play the audio clip.
            bgmAudioSource.Play();

            // Apply DontDestroyOnLoad only once.
            if (!gameObject.scene.isLoaded)
            {
                DontDestroyOnLoad(gameObject);
                Debug.Log("Music continue...");
                musicPersisted = true; // Set the flag to true.
            }
        }
    }


    private void Update()
    {
        // Check for player input to pause or resume the music.
        if (Input.GetKeyDown(KeyCode.P)) // You can change the input key to any key you prefer.
        {
            if (isMusicPaused)
            {
                Debug.Log("Music is resumed");
                ResumeMusic();
            }
            else
            {
                Debug.Log("Music is paused");
                PauseMusic();
            }
        }
    }
    private void PauseMusic()
    {
        // Check if the music is playing before pausing.
        if (bgmAudioSource.isPlaying)
        {
            // Save the current volume before pausing.
            savedVolume = bgmAudioSource.volume;
            // Pause the music.
            bgmAudioSource.Pause();
            // Set the flag to true to indicate that the music is paused.
            isMusicPaused = true;
        }
    }

    private void ResumeMusic()
    {
        // Check if the music is paused before resuming.
        if (!bgmAudioSource.isPlaying)
        {
            // Resume the music with the previously saved volume.
            bgmAudioSource.volume = savedVolume;
            bgmAudioSource.Play();
            // Set the flag to false to indicate that the music is resumed.
            isMusicPaused = false;
        }
    }

}
