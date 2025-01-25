using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class EnterRsgdoll : MonoBehaviour
{
    private Rigidbody[] rbs;
    private Animator animator;
    public float DeathTime;
    private NavMeshAgent agent;
    public bool isDead;
    void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        agent = GetComponentInChildren<NavMeshAgent>();
        foreach (var rb in rbs)
        {
            rb.isKinematic = true;
        }
        GetComponent<CapsuleCollider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Ragdoooooll();
        }
    }
    public void Ragdoooooll()
    {
        foreach (var rb in rbs)
        {
            rb.isKinematic = false;
        }
        GetComponent<CapsuleCollider>().enabled = false;
        animator.enabled = false;
        agent.enabled = false;
        isDead = true;
        StartCoroutine(DeathTimer());
    }

    private IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(DeathTime);
        Destroy(gameObject);
    }
}
