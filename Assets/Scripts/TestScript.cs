using System.Collections;
using UnityEngine;
namespace AG3961
{
    public class TestScript : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float time;
        [SerializeField] private bool goinUp;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            goinUp = false;
            StartCoroutine(SwitchDirection());
        }

        // Update is called once per frame
        private void Update()
        {
            if (goinUp)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }

            if(goinUp == false)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            
        }

        IEnumerator SwitchDirection()
        {
            yield return new WaitForSeconds(time);
            if (goinUp)
            {
                goinUp = false;
            }
            else
            {
                goinUp = true;
            }
            StartCoroutine(SwitchDirection());
        }
           
    }
}
