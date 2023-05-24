using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly float speed = 10f;
    private readonly float zBound = 7.5f;
    private readonly float xBound = 15f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame  
    void Update()
    {
        Aim();
        MovePlayer();
        KeepPlayerInBounds();
    }

    private void Aim()
    {
        Vector3 lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Determine which direction to rotate towards
        Vector3 targetDirection = (lookDirection - transform.position);
        Debug.DrawRay(transform.position, targetDirection, Color.red);
    }
    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        
        transform.Translate(speed * verticalInput * Time.deltaTime * Vector3.forward);
        transform.Translate(speed * horizontalInput * Time.deltaTime * Vector3.right);
    }

    private void KeepPlayerInBounds()
    {
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
    }
}
