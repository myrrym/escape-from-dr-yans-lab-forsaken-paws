using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;

    private AudioManagerScript audioManager;

    private void Start()
    {
        audioManager = AudioManagerScript.Instance;

        // Link the slider's OnValueChanged event to the SetVolume method.
        volumeSlider.onValueChanged.AddListener(SetVolume);

        // Set the initial volume value based on the current AudioManager's audio source volume.
        volumeSlider.value = audioManager.audioSource.volume;
    }

    private void SetVolume(float volume)
    {
        // Update the AudioManager's audio source volume based on the slider's value.
        audioManager.audioSource.volume = volume;
    }
}







