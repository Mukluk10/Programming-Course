using System.Collections;
using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float spawnTime;
    public GameObject funPolice;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(PoliceSpawnDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PoliceSpawnDelay()
    {
        yield return new WaitForSeconds(spawnTime);
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomSpawnIndex];
        Instantiate(funPolice, spawnPoint.position, spawnPoint.rotation);
    }
}
