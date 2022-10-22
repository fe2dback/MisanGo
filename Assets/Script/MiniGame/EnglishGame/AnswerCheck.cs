using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnswerCheck : MonoBehaviour
{
    public GameObject fail;
    public void ButtonClick()
    {
        if (QuizCheckBox.checkBox == true && QuizCheckBox2.checkBox == true && QuizCheckBox3.checkBox == true)
        {
            
            if(AnswerManager.instance.Quiz1 == true && AnswerManager.instance.Quiz2 == true && AnswerManager.instance.Quiz3 == true)
            {
                fail.SetActive(false);
                Debug.Log("clear");
                SceneManager.LoadScene("PlayScene");
            }
            else
            {
                Debug.Log("fail");
                fail.SetActive(true);
            }
            
        }
        else
        {
            Debug.Log("모든 항목을 체크해주세요");
        }
    }
}
