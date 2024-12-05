using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    float horizontalMove;
    float verticalMove;
    float speed = 3.0f;
    float xRange = 2.6f;
    float yRange = 2.1f;
    public GameObject projectilePrefab;
    public GameObject musicPrefab;
    float turnSpeed = 100.0f;

    public int lives;
    public GameObject[] hearts;
    public bool dead;
    
    public int score;

    public TMP_Text scoreText;

    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        lives = hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
        // move player
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(horizontalMove,verticalMove,0).normalized;
        transform.Translate(moveDir * Time.deltaTime * speed, Space.World);

        // play walk animation if player is moving
        if (horizontalMove != 0 || verticalMove != 0)
        {
            animator.Play("princessWalk");
        }

        // play idle animation if player is not moving or pressing buttons
        if (horizontalMove == 0 && verticalMove == 0 && Input.anyKeyDown == false)
        {
            animator.Play("princessIdle");
        }

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
            animator.Play("princessThrow");
            Instantiate(projectilePrefab, transform.position + transform.up, transform.rotation);

        }

        // spawn musical note (sing mechanic)
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.Play("princessSing");
            Instantiate(musicPrefab, transform.position + transform.up, transform.rotation);
        }

        // update score text
        scoreText.text = "Bunnies charmed: " + score;

        if (score == 50)
        {
            animator.Play("princessVictory");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "EvilBunny")
        {
            // lose a life
            TakeDamage(1);

            if (dead == true)
            {
                // Game over
                Debug.Log("Game over!");
                animator.Play("princessLose");
            } 
           
        }
    }

    void TakeDamage(int d)
    {
        if (lives >= 1)
        {
            lives -= d;
            Destroy(hearts[lives].gameObject);

            if(lives < 1) 
            {
                dead = true;
            }
        }
        
    }

}
