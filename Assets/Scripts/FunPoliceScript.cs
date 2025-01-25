using UnityEngine;
using UnityEngine.AI;

public class FunPoliceScript : MonoBehaviour
{
    public Transform playerObject;
    public NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(!playerObject)
        agent.SetDestination(playerObject.position);
    }
}
