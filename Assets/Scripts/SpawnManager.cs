using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float arenaRangeX = 22.0f;
    private float spawnPosZ = 5.0f;
    private float spawnPosY = 0.5f;
    private float enemySpawnRate = 4;
    private float obstacleSpawnRate = 3;
    private GameManager gameManager;

    public GameObject enemyPrefab;
    public GameObject obstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //InvokeRepeating(nameof(SpawnRandomEnemy), 2, 5);
        //InvokeRepeating(nameof(SpawnRandomObstacle), 1, 3);
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnEnemy()
    {
        while(gameManager.isGameActive)
        {
            yield return new WaitForSeconds(enemySpawnRate);
            SpawnRandomEnemy();
        }
    }

    IEnumerator SpawnObstacle()
    {
        while (gameManager.isGameActive)
        {
            yield return new WaitForSeconds(obstacleSpawnRate);
            SpawnRandomObstacle();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomObstacle()
    {
        Instantiate(obstaclePrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }
    void SpawnRandomEnemy()
    {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);  
    }

    Vector3 GenerateSpawnPosition()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-arenaRangeX, arenaRangeX), spawnPosY, spawnPosZ);
        return spawnPosition;
    }
}
