using UnityEngine;


namespace AG3961
{
    public class ObjectSpawner : MonoBehaviour
    {

        [SerializeField] private GameObject spawnedObject;

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Instantiate(spawnedObject, transform.position, Quaternion.identity);
            }
        }
    }
}
