using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class nextBotwaypoint : MonoBehaviour
{
    [SerializeField]
    public GameObject player;
    //enemy
    [SerializeField]
    private NavMeshAgent navAgent;

    [SerializeField]
    private Transform[] destinationPoints;

    [SerializeField]
    public float radius;

    [Range(0,360)]
    public float angle;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    private Vector3 currentDestination;

    private int destinationIndex;

    private bool moveToPlayer;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(FOVRoutine());
    }

    void Awake()
    {
        // get the current desination and make the agent
        // go towards that destination
        currentDestination = destinationPoints[Random.Range(0, destinationPoints.Length)].position;
        navAgent.destination = currentDestination;
    }

    void Update()
    {
        CheckIfAgentReachedDestination();
    }


    void SetNewDestination()
    {
        while (true)
        {
            destinationIndex = Random.Range(0, destinationPoints.Length);

            if (currentDestination != destinationPoints[destinationIndex].position)
            {
                currentDestination = destinationPoints[destinationIndex].position;
                navAgent.destination = currentDestination;
                Debug.Log("Set New Destination");
                break;
            }

        }
    }

    void CheckIfAgentReachedDestination()
    {
        if (!navAgent.pathPending)
        {
            if (navAgent.remainingDistance <= navAgent.stoppingDistance)
            {
                if (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f)
                {
                    if (moveToPlayer)
                    {
                        Debug.Log("Moving towards player");
                    }
                    else
                    {
                        Debug.Log("Finding New Destination");
                        SetNewDestination();
                    }
                }
            }
        }
    }

    private void OnCollisionEnter (Collision collision){
        if (collision.gameObject.tag == "player"){

        }
        Debug.Log("Player killed");
        SceneManager.LoadScene(0);
    }

    // reaction to player
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Moving towards player at : " + player.transform.position );
            moveToPlayer = true;
            navAgent.destination = player.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            moveToPlayer = false;
            SetNewDestination();
        }
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }

}
