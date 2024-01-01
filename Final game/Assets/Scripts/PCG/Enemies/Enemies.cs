using UnityEngine;

/* PCG - Generate enemies in a specific area */
public class Enemies : MonoBehaviour
{
    //enemy objects
    public GameObject enemy; 

    //difficulty mode check
    public DifficultyModes difficultyModes;

    //3d vector for the area center the enemies can spawn
    public Vector3 spawnAreaCenter; 

    //size of spawn area (will have length, width, height)
    public Vector3 spawnAreaSize; 

    //number of enemies to spawn, will have a range depending on difficulty mode
    private int numEnemies;

    //ranges for each difficulty mode - determines how many enemies will be generated (random in these bounds)
    private int easyLowerBound = 1;
    private int easyUpperBound = 2;

    private int normalLowerBound = 3;
    private int normalUpperBound = 6;

    private int hardLowerBound = 7;
    private int hardUpperBound = 10;

    private int veteranLowerBound = 11;
    private int veteranUpperBound = 14;
    
    void Start()
    {
        Debug.Log(difficultyModes.getMode());
        //on start check difficulty mode and spawn a number of enemies within a range depending on mode
        if (difficultyModes.getMode() == "Easy")
        {
            SpawnEnemy(Random.Range(easyLowerBound,easyUpperBound));
        }

        else if (difficultyModes.getMode() == "Hard")
        {
            SpawnEnemy(Random.Range(hardLowerBound,hardUpperBound));
        }

        else if (difficultyModes.getMode() == "Veteran")
        {
            SpawnEnemy(Random.Range(veteranLowerBound,veteranUpperBound));
        }

        //otherwise assume normal
        else 
        {
            SpawnEnemy(Random.Range(normalLowerBound,normalUpperBound));
        }

    }

    void SpawnEnemy(int amount)
    {
        //generate number of enemies based on amount given
        for (int i = 0; i < amount; i++)
        {
            //Spawn a new enemy randomly within the specified spawn area 
            Vector3 spawnPosition = new Vector3(
                Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2, spawnAreaCenter.x + spawnAreaSize.x / 2),
                Random.Range(spawnAreaCenter.y - spawnAreaSize.y / 2, spawnAreaCenter.y + spawnAreaSize.y / 2),
                Random.Range(spawnAreaCenter.z - spawnAreaSize.z / 2, spawnAreaCenter.z + spawnAreaSize.z / 2)
            );
            
            Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
    }
    
}
