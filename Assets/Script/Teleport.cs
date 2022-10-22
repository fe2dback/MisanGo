using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public GameObject targetObj;
    public GameObject checkObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            targetObj = collision.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && checkObj.CompareTag("TeacherRoom"))
        {
            SceneManager.LoadScene("TeacherRoom_Scene");
        }
        else if(collision.CompareTag("Player") && checkObj.CompareTag("ApplicationProgrammingRoom"))
        {
            SceneManager.LoadScene("ApplicationProgrammingRoom");
        }
        else if(collision.CompareTag("Player") && checkObj.CompareTag("hallway3"))
        {
            SceneManager.LoadScene("hallway3_Scene");
        }
        else if (collision.CompareTag("Player") && checkObj.CompareTag("Game1"))
        {
            SceneManager.LoadScene("Game1_Scene");
        }
        else if (collision.CompareTag("Player") && checkObj.CompareTag("Game2"))
        {
            SceneManager.LoadScene("Game2_Scene");
        }
        else if (collision.CompareTag("Player") && checkObj.CompareTag("hallway4"))
        {
            SceneManager.LoadScene("hallway4_Scene");
        }
    }
}
