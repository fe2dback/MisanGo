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
        else if(SceneNumber == 4)
        {
            player = Instantiate(charPrefabs[(int)DataMgr.instance.currentCharacter]);
            player.transform.position = transform.position;
        }
        else
        {
            player = Instantiate(charPrefabs[(int)DataMgr.instance.currentCharacter]);
            player.transform.position = DataMgr.instance.playerTp;
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}
