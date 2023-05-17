using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float arenaRangeX = 15.0f;
    private float arenaRangeZ = 7.5f;
    private (float, float)[] spawnRangesX = new[] { (-22.0f, -18.0f), (18.0f, 22.0f) };
    private (float, float)[] spawnRangesZ = new[] { (8.0f, 12.0f), (-8.0f, -12.0f) };

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomEnemy), 2, 5);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomEnemy()
    {
        // decide if enemy is gonna be spawned on the horizontal or vertical axis
        // 1 - horizontal
        // 2 - vertical

        int spawnOrientation = Random.Range(1, 3);
        Vector3 spawnPosition;

        if (spawnOrientation == 1)
        {
            float randomZ = Random.Range(-arenaRangeZ, arenaRangeZ);
            int randomSide = Random.Range(0, spawnRangesX.Length);
            var (x1, x2) = spawnRangesX[randomSide];
            float randomX = Random.Range(x1, x2);
            spawnPosition = new Vector3(randomX, 0, randomZ);
        }
        else
        {
            float randomX = Random.Range(-arenaRangeX, arenaRangeX);
            int randomSide = Random.Range(0, spawnRangesZ.Length);
            var (z1, z2) = spawnRangesZ[randomSide];
            float randomZ = Random.Range(z1, z2);
            spawnPosition = new Vector3(randomX, 0, randomZ);
        }

        Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
    }

    Vector3 GenerateSpawnPosition()
    {
        int randomXindex = Random.Range(0, spawnRangesX.Length);
        int randomZindex = Random.Range(0, spawnRangesZ.Length);



        return new Vector3(0, 0, 0);
    }
}
