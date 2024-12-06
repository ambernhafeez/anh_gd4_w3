using UnityEngine;

public class CharmBunny : MonoBehaviour
{
    
    public GameObject niceBunny;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // transform into nice bunny when hit with musical note
    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.transform.tag == "Music")
        {
            // change evil bunny into nice bunny

            Instantiate(niceBunny, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
}
