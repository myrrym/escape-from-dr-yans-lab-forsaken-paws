using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool levelComplete = false;
    public float restartDelay = 5f;
    public GameObject completeLevelUI;
    public GameObject levelItem; // Reference to the specific object you want to trigger the completion

    void Start()
    {
        completeLevelUI.SetActive(false);
    }

    void Update()
    {
        // Add any necessary game management logic here if needed
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered lift");
        // Check if the object that entered the trigger is the levelItem
        if (other.gameObject == levelItem)
        {
            Debug.Log("Level Item entered trigger.");
            completedLevel();
        }
    }

    public void completedLevel()
    {
        if (!levelComplete)
        {
            levelComplete = true;
            completeLevelUI.SetActive(true);
            Debug.Log("Level Complete!!!!");
            Invoke("restart", restartDelay);
        }
    }

    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
