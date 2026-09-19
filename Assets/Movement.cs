using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Transform Goal;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {


        agent.destination = Goal.position;
    }
}