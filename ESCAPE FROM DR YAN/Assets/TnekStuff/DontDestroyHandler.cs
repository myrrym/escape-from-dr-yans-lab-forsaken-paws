using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyHandler : MonoBehaviour
{
    // Add GameObject references that you want to destroy when transitioning to "floor4" scene.
    public GameObject[] objectsToDestroy;

    private void Start()
    {
        Debug.Log("Current scene: " + SceneManager.GetActiveScene().name);
        //Destroy(gameObject);
        if (SceneManager.GetActiveScene().name == "floor4")
        {
            Debug.Log("Destroying specified GameObjects in 'floor4' scene.");
            foreach (GameObject obj in objectsToDestroy)
            {
                Debug.Log("Destroying: " + obj.name);
                Destroy(obj);
            }
        }


    }
    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "floor4")
        {
            Debug.Log("Destroying specified GameObjects in 'floor4' scene.");
            foreach (GameObject obj in objectsToDestroy)
            {
                Debug.Log("Destroying: " + obj.name);
                Destroy(obj);
            }
        }

    }
    private void OnDestroy()
    {
        Debug.Log("DontDestroyHandler is being destroyed.");
    }
}
