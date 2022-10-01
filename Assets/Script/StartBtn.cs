using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{

    public void ButtonClick()
    {
        if(CheckBox.checkBox == true)
        {
            SceneManager.LoadScene("PlayScene");
        }
        else
        {
            Debug.Log("성별을 체크해주세요.");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
