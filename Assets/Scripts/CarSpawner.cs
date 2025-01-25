using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float spawnTime;
    public float spawnSpeed;
    public GameObject[] vehicle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CarSpawnDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator CarSpawnDelay()
    {
        yield return new WaitForSeconds(spawnTime);
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomSpawnIndex];

        // Instantiate the object at the chosen spawn point
        int randomObjectIndex = Random.Range(0, vehicle.Length);
        GameObject spawnObject = vehicle[randomObjectIndex];
        GameObject spawnedObject = Instantiate(spawnObject, spawnPoint.position, spawnPoint.rotation);
        StartCoroutine(CarSpawnDelay());
    }
}
