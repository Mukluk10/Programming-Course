using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float spawnTime;
    public float spawnSpeed;
    public GameObject[] vehicle;
    public VFXSpawnPos vfx;
    public float maxSpeed;
    public float moveSpeed;
    private List<Car> spawnedCars = new List<Car>();
    public bool isCarSpawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CarSpawnDelay());
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < spawnedCars.Count; i++)
        {
            vfx.spawnGas.Add(spawnedCars[i].rb.transform.position + Quaternion.Euler(0, spawnedCars[i].rb.transform.rotation.eulerAngles.y, 0) * new Vector3(0, UnityEngine.Random.Range(.2f, 1f), -1.5f));
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < spawnedCars.Count; i++)
        {
            if (!spawnedCars[i].bubbleHit.isInBubble)
            {
                if (spawnedCars[i].rb.linearVelocity.magnitude < maxSpeed)
                {
                    spawnedCars[i].rb.linearVelocity += spawnedCars[i].rb.transform.forward * moveSpeed * Time.fixedDeltaTime;
                }
                else
                {
                    spawnedCars[i].rb.linearVelocity = Vector3.ClampMagnitude(spawnedCars[i].rb.linearVelocity, maxSpeed);
                }
            }
        }
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
        if (isCarSpawner)
        {
            spawnedCars.Add(new Car(ResMgr.GenID(), spawnedObject.GetComponent<Rigidbody>(), spawnedObject.GetComponent<BubbleHit>()));
        }
        StartCoroutine(CarSpawnDelay());
    }
}

public class Car
{
    public int id;
    public Rigidbody rb;
    public BubbleHit bubbleHit;

    public Car(int id, Rigidbody rb, BubbleHit bubbleHit)
    {
        this.id = id;
        this.rb = rb;
        this.bubbleHit = bubbleHit;
    }
}
