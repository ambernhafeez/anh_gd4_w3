using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animals;
    float spawnRangeX = 2.7f;
    float spawnRangeY = 2.2f;

    private float startDelay = 5;
    private float spawnInterval = 1.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

        //if (transform.position.x > spawnRangeX || transform.position.x < -spawnRangeX || transform.position.y > spawnRangeY || transform.position.y < -spawnRangeY) 
        //{
        //    Destroy(gameObject);
        //}

    }

    void SpawnRandomAnimal() 
    {
        // spawn animal in random direction
        int randomIndex = Random.Range(0, animals.Length);
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeY, spawnRangeY));
            
        Instantiate(animals[randomIndex], randomSpawnPosition, Quaternion.Euler(0, 0, Random.Range(0, 360)));

    }
}