using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Transform Goal;
    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {

        agent.destination = Goal.position;
    }
}
