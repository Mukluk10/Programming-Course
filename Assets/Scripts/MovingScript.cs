using UnityEngine;

public class MovingScript : MonoBehaviour
{
    public float moveSpeed;
    public float maxSpeed;
    private Rigidbody rb;
    BubbleHit bubbleHitScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bubbleHitScript = GetComponent<BubbleHit>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {
        // Check if the object is not in a bubble
        if (!bubbleHitScript.isInBubble)
        {
            // Only apply force if the velocity is below the maximum speed
            if (rb.linearVelocity.magnitude < maxSpeed)
            {
                rb.AddForce(transform.forward * moveSpeed * Time.fixedDeltaTime);
            }
            else
            {
                // Optional: Cap velocity to maxSpeed if it exceeds the limit
                rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxSpeed);
            }
        }
    }
}
