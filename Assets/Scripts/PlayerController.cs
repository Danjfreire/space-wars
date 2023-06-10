using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    private readonly float speed = 15f;
    private readonly float xBound = 22f;
    private readonly float fireCooldown = 0.33f;
    private float currentFireCooldown = 0.0f;

    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame  
    void Update()
    {
        if (gameManager.isGameActive)
        {
            MovePlayer();
            KeepPlayerInBounds();
            Fire();
        }
    }


    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(speed * horizontalInput * Time.deltaTime * Vector3.right);
    }

    private void KeepPlayerInBounds()
    {

        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
    }

    private void Fire()
    {
        if (currentFireCooldown > 0.0f)
        {
            currentFireCooldown -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space) && currentFireCooldown <= 0.0f)
        {
            Instantiate(projectile, transform.position, projectile.transform.rotation);
            currentFireCooldown = fireCooldown;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy Bullet") || other.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            this.gameManager.GameOver();
        }
    }
}
