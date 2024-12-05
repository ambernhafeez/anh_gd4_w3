using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    float speed = 4.5f;
    //float rotationSpeed = 40.0f;
    private float topBound = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * Time.deltaTime * speed);

        if (transform.position.x > topBound || transform.position.x < -topBound || transform.position.y > topBound || transform.position.y < -topBound) 
        {
            Destroy(gameObject);
        }
    }
}
