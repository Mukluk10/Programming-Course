using UnityEngine;
using UnityEngine.AI;

public class FunPoliceScript : MonoBehaviour
{
    public GameObject playerObject;
    public NavMeshAgent agent;
    public EnterRsgdoll ragScript;
    public Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ragScript = GetComponent<EnterRsgdoll>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!ragScript.isDead)
        {
            agent.SetDestination(playerObject.transform.position);
            float distance = Vector3.Distance(transform.position, playerObject.transform.position);

            if (distance < 2) 
            {
                Attack();
            }
        }
        
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
    }
}
