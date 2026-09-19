using UnityEngine;
using UnityEngine.AI;

public class ragdoll : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        Debug.Log("collidedgameobjectname; " + col.gameObject.name + "playername; " + player.name);
        if (col.gameObject.name==player.name)
        {
            Debug.Log("raggin");

            agent = GetComponent<NavMeshAgent>();
            agent.enabled = false;
        }
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
