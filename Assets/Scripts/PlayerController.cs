using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{

    public float speed;
    private float zBound = 23;
    private float xBound = 23;


    public GameObject barrelTip;
    public float bulletSpeed = 50.0f;
    public ParticleSystem greenLineParticle;
    public AudioSource reloadSound;


    // Start is called before the first frame update
    void Start()
    {
        reloadSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        ConstrainPlayerPosition();
        PlayerMovement();
        PlayerRotation();

        

    }

    //Prevent player from leaving game area
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

    // Character controls using arrow keys
    void PlayerMovement()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }



    }

    //Aim and rotate player to position of mouse cursor
    void PlayerRotation()
    {

        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float dist;
        if (plane.Raycast(ray, out dist))
        {
            transform.LookAt(ray.GetPoint(dist));

        }
        
    }


    //Check Collision with Enemy

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit By Enemy");
        }
    }

    // Check collision with Ammo

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            Instantiate(greenLineParticle, other.gameObject.transform.position, greenLineParticle.transform.rotation);
            reloadSound.Play();
        }
    }
}