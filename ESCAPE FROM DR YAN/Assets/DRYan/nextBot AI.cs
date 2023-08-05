using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class nextBotAI : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;
    }

    private void OnCollisionEnter (Collision collision){
        if (collision.gameObject.tag == "player"){

        }
        SceneManager.LoadScene(0);
    }

    //private void 
    // Time.deltaTime
}
