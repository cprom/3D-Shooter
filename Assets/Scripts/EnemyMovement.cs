using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 1000.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    private float zBound = 23;
    private float xBound = 23;


    // Start is called before the first frame update
    void Start()
    {
        
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
        
    {
        ConstrainPlayerPosition();
        
        // Make enemy go to player's position
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed );
        transform.LookAt(lookDirection);
    }


    //Method that Prevent enemies from leaving the game area
    void ConstrainPlayerPosition()
    {

        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
    }

}
