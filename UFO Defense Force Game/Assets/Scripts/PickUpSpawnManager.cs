using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawnManager : MonoBehaviour
{
    public GameObject[] pickupPrefabs;

    [SerializeField]
    private float spawnRangeX = 10.0f;
    [SerializeField]
    private float spawnPosZ;

    private float startDelay = 2f;
    private float spawnInterval = 6f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomPickUp", startDelay, spawnInterval);
    }

    void SpawnRandomPickUp()
    {
        // Generate a position to spawn at
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        // Pick a random pickup from array
        int pickupIndex = Random.Range(0,pickupPrefabs.Length);
        // Spawn pickup indexed from the array
        Instantiate(pickupPrefabs[pickupIndex], spawnPos, pickupPrefabs[pickupIndex].transform.rotation);
    }
}
