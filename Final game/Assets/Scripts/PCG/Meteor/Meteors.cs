using UnityEngine;

/* PCG - Create random meteors in the sky - this script handles the creation of these objects */
public class Meteors : MonoBehaviour
{
    //meteor objects
    public GameObject meteor; 

    //3d vector for the area center the meteors can spawn
    public Vector3 spawnAreaCenter; 

    //size of spawn area (will have length, width, height)
    public Vector3 spawnAreaSize; 

    //time between each spawn waves
    public float spawnInterval = 2f; 
    private float timeSinceLastSpawn;
    
    void Start()
    {
        //initiliase time since last spawn
        timeSinceLastSpawn = 0;
    }

    void Update()
    {
        //create timer using deltatime which tracks time since last spawn, spawn a meteor after each interval passes (2 seconds)
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnMeteor();
            timeSinceLastSpawn = 0;
        }
    }

    void SpawnMeteor()
    {
        //Spawn a new meteor randomly within the specified spawn area 
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2, spawnAreaCenter.x + spawnAreaSize.x / 2),
            Random.Range(spawnAreaCenter.y - spawnAreaSize.y / 2, spawnAreaCenter.y + spawnAreaSize.y / 2),
            Random.Range(spawnAreaCenter.z - spawnAreaSize.z / 2, spawnAreaCenter.z + spawnAreaSize.z / 2)
        );

        Instantiate(meteor, spawnPosition, Quaternion.identity);
    }
    
}
