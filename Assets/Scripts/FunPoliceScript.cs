using UnityEngine;
using UnityEngine.AI;

public class FunPoliceScript : MonoBehaviour
{
    public Transform playerObject;
    public NavMeshAgent agent;
    public EnterRsgdoll ragScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ragScript = GetComponent<EnterRsgdoll>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!ragScript.isDead)
        {
            agent.SetDestination(playerObject.position);
        }
        
    }
}
