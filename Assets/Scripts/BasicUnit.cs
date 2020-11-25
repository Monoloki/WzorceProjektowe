using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicUnit : MonoBehaviour
{
    GameObject waypoint1;
    GameObject finish;
    NavMeshAgent theAgent;
    public int pivotpoint = 0;
    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();
        waypoint1 = GameObject.Find("waypoint_1");  
        finish = GameObject.Find("nexus");
    }


    void Update()
    {
        if (pivotpoint == 0)
        {
            theAgent.SetDestination(waypoint1.transform.position);
            pivotpoint = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "waypoint")
        {
            theAgent.SetDestination(finish.transform.position);
        }
        
    }
}
