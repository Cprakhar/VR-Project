using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentWayPointIndex = 0;
    public Transform[] wayPoints;
    public GameObject Path;
    public float minDistance = 0.1f;
    public float speed = 1.0f;
    Animator animator;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        wayPoints = new Transform[Path.transform.childCount];
        for(int i=0; i<wayPoints.Length; i++)
        {
            wayPoints[i] = Path.transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, wayPoints[currentWayPointIndex].position) < minDistance)
        {
            currentWayPointIndex++;
            if(currentWayPointIndex >= wayPoints.Length)
            {
                currentWayPointIndex = 0;
            }
        }
        agent.SetDestination(wayPoints[currentWayPointIndex].position);
        // animator.SetFloat("Walking", agent.isStopped ? 0 : 1);
    }
}
