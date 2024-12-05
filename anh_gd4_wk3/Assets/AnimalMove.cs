using UnityEngine;

public class AnimalMove : MonoBehaviour
{
    public float speed = 2.0f;
    float rotationSpeed = 40.0f;
    private float topBound = 2.9f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        //transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);

        if (transform.position.x > topBound || transform.position.x < -topBound || transform.position.y > topBound || transform.position.y < -topBound) 
        {
            //Destroy(gameObject);

            // move in random direction
            transform.rotation =  Quaternion.Euler(0, 0, Random.Range(0, 360));

        }
    }

    // mechanic to get destroyed on collision with projectile
    private void OnTriggerEnter2D(Collision2D other)
    {
        if(other.transform.tag == "Projectile")
        {
            // Destroy projectile
            Destroy(other.gameObject);

            // Destroy self
            Destroy(gameObject);

            // Update score by accessing player controller script
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().score ++;
        }
    }
}
