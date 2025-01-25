using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    public float timer;
    public bool isFloating;
    public Collider col;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isFloating)
        {
            if (other.CompareTag("Object"))
            {
                isFloating = true;
                Debug.Log("Trigger");
                StartCoroutine(BubbleExplodeTime());
            }
            else
            {
                Debug.Log("Trigger ELse");
                Destroy(gameObject);
            }
        }
        
    }

    public IEnumerator BubbleExplodeTime()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
