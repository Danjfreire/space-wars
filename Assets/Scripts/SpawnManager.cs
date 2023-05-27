using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float arenaRangeX = 22.0f;
    private float spawnPosZ = 5.0f;
    private float spawnPosY = 0.5f;

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
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    Vector3 GenerateSpawnPosition()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-arenaRangeX, arenaRangeX), spawnPosY, spawnPosZ);
        return spawnPosition;
    }
}
