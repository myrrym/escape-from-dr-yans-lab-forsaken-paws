using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public AudioSource buttonClickSound; // Reference to the AudioSource for the button click sound.

    public void StartGame()
    {
        Debug.Log("Button clicked to change Scene: Floor4");

        // Play the button click sound (if the AudioSource is assigned).
        if (buttonClickSound != null)
        {
            Debug.Log("Button Sound is Played");
            buttonClickSound.Play();
            if(buttonClickSound == true) 
            {
                SceneManager.LoadScene("floor4");
            }
                
        }
        else
        {
            Debug.Log("No Sound is assigned");
        }

    }
    public void QuitGame()
    {
        // Quit the application when the button is clicked.
        if (buttonClickSound != null)
        {
            Debug.Log("Button Sound is Played");
            buttonClickSound.Play();
        }
        else
        {
            Debug.Log("No Sound is assigned");
        }
        
    }
    public void BackToMainMenu()
    {
        Debug.Log("Button clicked to change Scene: Main Menu");

        // Play the button click sound (if the AudioSource is assigned).
        if (buttonClickSound != null)
        {
            Debug.Log("Button Sound is Played");
            buttonClickSound.Play();
            if (buttonClickSound == true)
            {
                SceneManager.LoadScene("MainMenu");
            }

        }
        else
        {
            Debug.Log("No Sound is assigned");
        }

    }
    public void GoToSelectFloor()
    {
        Debug.Log("Button clicked to change Scene: Floor Option");

        // Play the button click sound (if the AudioSource is assigned).
        if (buttonClickSound != null)
        {
            Debug.Log("Button Sound is Played");
            buttonClickSound.Play();
            if (buttonClickSound == true)
            {
                SceneManager.LoadScene("FloorOption");
            }

        }
        else
        {
            Debug.Log("No Sound is assigned");
        }

    }
    public void GoToVolumeSettings()
    {
        Debug.Log("Button clicked to change Scene: Sound Settings");

        // Play the button click sound (if the AudioSource is assigned).
        if (buttonClickSound != null)
        {
            Debug.Log("Button Sound is Played");
            buttonClickSound.Play();
            if (buttonClickSound == true)
            {
                SceneManager.LoadScene("SoundSetting");
            }

        }
        else
        {
            Debug.Log("No Sound is assigned");
        }

    }
}
