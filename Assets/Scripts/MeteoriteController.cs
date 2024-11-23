using System;
using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // Array of prefabs to spawn
    public RandomSpawnArea spawnArea; // Reference to the spawn area
    public int numberOfObjects = 10; // Total number of objects to spawn
    public float spawnInterval = 1f; // Time interval between spawns in seconds
    public float destroyInterval = 3f; // Time after which the object is destroyed

    private int spawnedObjects = 0; // Counter for spawned objects
    private bool isStop;

    private void Start()
    {
        // Start the timed spawning process
        InvokeRepeating(nameof(SpawnObject), 0f, spawnInterval);
    }

    /// <summary>
    /// Spawns an object at a random position within the defined area.
    /// Randomly selects a prefab from the array to spawn.
    /// Stops spawning when the target number of objects is reached.
    /// </summary>
    private void SpawnObject()
    {
        if (spawnedObjects < numberOfObjects && !isStop)
        {
            // Randomly select a prefab from the array
            GameObject prefabToSpawn = prefabsToSpawn[UnityEngine.Random.Range(0, prefabsToSpawn.Length)];

            // Get a random position within the spawn area
            Vector3 spawnPosition = spawnArea.GetRandomPosition();

            // Instantiate the selected prefab
            GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

            // Increment the counter and schedule destruction of the spawned object
            spawnedObjects++;
            Destroy(spawnedObject, destroyInterval);
        }
        else
        {
            // Stop the spawning process once the desired number is reached
            CancelInvoke(nameof(SpawnObject));
        }
    }

    /// <summary>
    /// Stops the spawning process if required externally.
    /// </summary>
    public void OnStopSpawning()
    {
        isStop = true;
    }
}
