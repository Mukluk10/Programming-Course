using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class BubbleScript : MonoBehaviour
{
    public float timer;
    public bool isFloating;
    public float floatSpeed;
    [SerializeField] private Rigidbody rb;
    public VisualEffect vfx;
    public MeshRenderer rend;
    public Collider col;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isFloating)
        {
            rb.AddForce(Vector3.up * floatSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isFloating)
        {
            col.enabled = false;
            if (other.CompareTag("Object"))
            {
                isFloating = true;
                Debug.Log("Trigger");
                StartCoroutine(BubbleExplodeTime());
            }
            else
            {
                Debug.Log("Trigger ELse");
                rend.enabled = false;
                vfx.Play();
                StartCoroutine(PopTime());
            }
        }
        
    }

    public IEnumerator BubbleExplodeTime()
    {
        yield return new WaitForSeconds(timer);
        vfx.Play();
        rend.enabled = false;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private IEnumerator PopTime()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
