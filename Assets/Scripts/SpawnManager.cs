using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalsPrefab;
    public GameObject[] dogRightPrefab;
    public GameObject[] dogLeftPrefab;
    public GameObject energyDrink;

    private float animalStartDelay = 2.0f;
    private float dogRightStartDelay = 5.0f;
    private float dogLeftStartDelay = 7.0f;
    private float healthStartDelay = 10.0f;

    private float animalSpawnInterval;
    private float dogRightSpawnInterval;
    private float dogLeftSpawnInterval;
    private float healthSpawnInterval;


    // Start is called before the first frame update
    void Start()
    {
        // sets spawn intervals to random ranges for each type
        animalSpawnInterval = Random.Range(2, 3);
        dogRightSpawnInterval = Random.Range(3, 7);
        dogLeftSpawnInterval = Random.Range(4, 8);
        healthSpawnInterval = Random.Range(8, 10);

        // spawns random animals, dogs, and health at different delays and intervals
        InvokeRepeating("SpawnRandomAnimal", animalStartDelay, animalSpawnInterval);
        InvokeRepeating("SpawnRandomDogRight", dogRightStartDelay, dogRightSpawnInterval);
        InvokeRepeating("SpawnRandomDogLeft", dogLeftStartDelay, dogLeftSpawnInterval);
        InvokeRepeating("SpawnRandomHealth", healthStartDelay, healthSpawnInterval);
    }

    // spawns animals from the top of the screen
    void SpawnRandomAnimal()
    {
        float animalSpawnPosZ = 20;
        float animalSpawnPosX = Random.Range(-15, 15);
        int animalIndex = Random.Range(0, animalsPrefab.Length);
        Vector3 animalSpawnPos = new Vector3(animalSpawnPosX, 0, animalSpawnPosZ);

        Instantiate(animalsPrefab[animalIndex], animalSpawnPos, animalsPrefab[animalIndex].transform.rotation);
    }

    // spawns dog enemies from the right of the screen
    void SpawnRandomDogRight()
    {
        float dogSpawnPosX = 28;
        float dogSpawnPosZ = Random.Range(0, 15);
        int dogIndex = Random.Range(0, dogRightPrefab.Length);
        Vector3 dogSpawnPos = new Vector3(dogSpawnPosX, 0, dogSpawnPosZ);

        Instantiate(dogRightPrefab[dogIndex], dogSpawnPos, dogRightPrefab[dogIndex].transform.rotation);
    }

    // spawns dog enemies from the left of the screen
    void SpawnRandomDogLeft()
    {
        float dogSpawnPosX = -28;
        float dogSpawnPosZ = Random.Range(0, 15);
        int dogIndex = Random.Range(0, dogLeftPrefab.Length);
        Vector3 dogSpawnPos = new Vector3(dogSpawnPosX, 0, dogSpawnPosZ);

        Instantiate(dogLeftPrefab[dogIndex], dogSpawnPos, dogLeftPrefab[dogIndex].transform.rotation);
    }

    // spawns random health (energy drinks) on the playing field
    void SpawnRandomHealth()
    {
        float healthSpawnPosX = Random.Range(-15, 15);
        float healthSpawnPosZ = Random.Range(0, 15);
        Vector3 healthSpawnPos = new Vector3(healthSpawnPosX, 0, healthSpawnPosZ);

        Instantiate(energyDrink, healthSpawnPos, energyDrink.transform.rotation);
    }
}
