using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && timer <= 0)
        {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                timer = 2;
        }
    }
}
