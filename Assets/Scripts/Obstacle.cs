using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameManager gameManager;
    private SpawnManager spawnManager;

    public int spawnIndex;

    // Start is called before the first frame update
    void Start()
    {
        this.gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        this.spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        spawnManager.FreeSpawnAtPosition((int) Math.Floor(transform.position.x));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sensor"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Player Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            this.gameManager.UpdateScore(5);
        }
    }
}
