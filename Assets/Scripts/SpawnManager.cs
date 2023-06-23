using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int arenaRangeX = 22;
    private int enemySpacing = 2;
    private float spawnPosZ = 5.0f;
    private float spawnPosY = 0.5f;
    private float enemySpawnRate = 4;
    private float obstacleSpawnRate = 3;
    private GameManager gameManager;
    private List<int> spawnxPositions = new List<int>();
    private List<bool> availableSpawnPositions = new List<bool>();

    public GameObject[] spawnPositions;
    public GameObject enemyPrefab;
    public GameObject obstaclePrefab;

 
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void StartSpawning()
    {
        InitializeSpawnPositions();

        StartCoroutine(Spawn(enemyPrefab, enemySpawnRate));
        StartCoroutine(Spawn(obstaclePrefab, obstacleSpawnRate));
    }

    private void InitializeSpawnPositions()
    {
        for (int i = -arenaRangeX; i < arenaRangeX; i += enemySpacing)
        {
            spawnxPositions.Add(i);
            availableSpawnPositions.Add(true);
        }
    }

    public void FreeSpawnAtPosition(int xPosition)
    {
        int index = spawnxPositions.IndexOf(xPosition);
        //Debug.Log("Position : " + xPosition + " | " +"Index : " + index);
        availableSpawnPositions[index] = true;
    }

    IEnumerator Spawn(GameObject obj, float spawnRate)
    {
        while (gameManager.isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            TryToSpawnAtRandomPosition(obj);
        }
    }

    void TryToSpawnAtRandomPosition(GameObject obj)
    {
        int tries = 0;
        while (tries < 3)
        {
            int spawnIndex = UnityEngine.Random.Range(0, spawnxPositions.Count);
            if (availableSpawnPositions[spawnIndex])
            {
               Instantiate(
                    obj,
                    new Vector3(spawnxPositions[spawnIndex], spawnPosY, spawnPosZ), 
                    obj.transform.rotation);
                availableSpawnPositions[spawnIndex] = false;
                return;
            }
            tries++;
        }
    }
}
