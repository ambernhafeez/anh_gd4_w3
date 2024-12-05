using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    float horizontalMove;
    float verticalMove;
    float speed = 3.0f;
    float xRange = 2.6f;
    float yRange = 2.1f;
    public GameObject projectilePrefab;
    float turnSpeed = 100.0f;
    
    public int score;

    public TMP_Text scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move player
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(horizontalMove,verticalMove,0).normalized;
        transform.Translate(moveDir * Time.deltaTime * speed, Space.World);

        // rotate player in movement direction 
        if (horizontalMove == 1) {
            transform.Rotate(Vector3.forward);
            transform.rotation = Quaternion.Euler(0,0,-90);
        }
        if (horizontalMove == -1) {
            transform.Rotate(Vector3.back);
            transform.rotation = Quaternion.Euler(0,0,90);
        }
        if (verticalMove == 1) {
            transform.Rotate(Vector3.forward);
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        if (verticalMove == -1) {
            transform.Rotate(Vector3.back);
            transform.rotation = Quaternion.Euler(0,0,180);
        }

        // keep player in bounds
        if (transform.position.x < -xRange) {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange) {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -yRange) {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }
        if (transform.position.y > yRange) {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }

        // spawn projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

            // spawn object one space in front of player with its default rotation
            Instantiate(projectilePrefab, transform.position + new Vector3(0,0,1), transform.rotation);

        }

        // update score text
        scoreText.text = "Bunnies charmed: " + score;
    }
}
