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
            SceneManager.LoadScene(4);
        }
        else if(collision.CompareTag("Player") && checkObj.CompareTag("hallway3"))
        {
            SceneManager.LoadScene(3);
        }
    }
}
