using UnityEngine;
using UnityEngine.UI;

public class HungerManager : MonoBehaviour
{
    public Image hungerBar;
    public float hungerAmount = 100f;
    public float drainSpeed = 15;
    public GameObject evilBunny;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // reduce hunger amount over time multiplied by drain speed
        hungerAmount -= Time.deltaTime * drainSpeed;
        // adjust the fillAmount of the UI Image which has a fill property
        hungerBar.fillAmount = hungerAmount / 100f;

        // change bunny into evil bunny if hunger bar is empty
        if (hungerAmount <= 0)
        {
            Instantiate(evilBunny, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    // mechanic to get destroyed on collision with projectile
    void OnTriggerEnter2D(Collider2D other)
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