using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReSpawn : MonoBehaviour
{
    public GameObject[] charPrefabs;
    public GameObject player;
    public int SceneNumber;
    // Start is called before the first frame update
    void Start()
    {
        SceneNumber = SceneManager.GetActiveScene().buildIndex;
        if (DataMgr.instance.startCheck == false)
        {
            player = Instantiate(charPrefabs[(int)DataMgr.instance.currentCharacter]);
            player.transform.position = transform.position;
            DataMgr.instance.startCheck = true;
        }
        else if(SceneNumber == 5 || SceneNumber == 6)
        {
            player = Instantiate(charPrefabs[(int)DataMgr.instance.currentCharacter]);
            player.transform.position = transform.position;
        }
        else if(SceneNumber == 3 && DataMgr.instance.AppSceneCheck == true)
        {
            player = Instantiate(charPrefabs[(int)DataMgr.instance.currentCharacter]);
            player.transform.position = transform.position;
            DataMgr.instance.AppSceneCheck = false;
        }   
        else if(SceneNumber == 6 && DataMgr.instance.FindDfImg == true)
        {
            player = Instantiate(charPrefabs[(int)DataMgr.instance.currentCharacter]);
            player.transform.position = transform.position;
            DataMgr.instance.FindDfImg = false;
        }
        else
        {
            player = Instantiate(charPrefabs[(int)DataMgr.instance.currentCharacter]);
            player.transform.position = DataMgr.instance.playerTp;
        }

    }

}
