using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TP_Zone : MonoBehaviour
{
    public int nextZone;
    public int actualZone;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(nextZone, LoadSceneMode.Single);
        }
    }
}
