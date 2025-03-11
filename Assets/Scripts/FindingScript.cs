using AG3961;
using UnityEngine;

public class FindingScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public Animator anim;
    public TestScript teeeestSCriiipt;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        teeeestSCriiipt = FindAnyObjectByType<TestScript>();
    }

    // Update is called once per frame
    void Update()
    {
        teeeestSCriiipt.speed = 50;
    }
}
