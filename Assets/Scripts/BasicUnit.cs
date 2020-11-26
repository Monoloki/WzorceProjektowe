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

        if (pivotpoint == 0)
        {
            theAgent.SetDestination(waypoint1.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Waypoint")
        {
            theAgent.SetDestination(finish.transform.position);
        }
        if (other.tag == "Nexus")
        {
            Destroy(gameObject);
        }
    }
}
