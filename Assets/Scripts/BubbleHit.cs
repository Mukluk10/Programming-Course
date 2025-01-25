using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleHit : MonoBehaviour
{
    public bool isInBubble;
    public float floatingTime;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bubble") && !isInBubble)
        {
            isInBubble = true;
            rb.isKinematic = true;
            gameObject.transform.SetParent(other.transform);
            gameObject.transform.position = other.transform.position;
            StartCoroutine(FloatingInBubbleTimer());
        }
    }

    public IEnumerator FloatingInBubbleTimer()
    {
        yield return new WaitForSeconds(floatingTime);
        rb.isKinematic = false;
        gameObject.transform.SetParent(null);
        yield return new WaitForSeconds(0.2f);
        isInBubble = false;
    }

}
