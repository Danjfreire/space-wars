using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private float zPosition = 1.0f;
    private float speed = 5.0f;
    private float fireCooldown = 1.0f;
    private float currentFireCooldown = 0.0f;
    private GameManager gameManager;
    private SpawnManager spawnManager;
    private bool atPosition = false;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCenter");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameManager.isGameActive)
        {
            moveToPosition();
            FireAtPlayer();
        }
    }

    private void moveToPosition()
    {
        if (transform.position.z > zPosition)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.forward);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);
            atPosition = true;
        }
    }

    private void FireAtPlayer()
    {
        if(!atPosition)
        {
            return;
        }

        Vector3 playerPos = player.transform.position;
        transform.LookAt(playerPos);

        if (currentFireCooldown > 0.0f)
        {
            currentFireCooldown -= Time.deltaTime;
        }

        if (currentFireCooldown <= 0.0f)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            currentFireCooldown = fireCooldown;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player Bullet"))
        {
            spawnManager.FreeSpawnAtPosition((int)Math.Floor(transform.position.x));
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameManager.UpdateScore(10);
        }

    }
}
