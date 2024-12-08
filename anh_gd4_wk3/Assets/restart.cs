using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class restart : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    } 
}
