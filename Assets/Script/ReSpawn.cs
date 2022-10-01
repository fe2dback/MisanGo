using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour
{
    public GameObject[] charPrefabs;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if(DataMgr.instance.startCheck == false)
        {
            player = Instantiate(charPrefabs[(int)DataMgr.instance.currentCharacter]);
            player.transform.position = transform.position;
            DataMgr.instance.startCheck = true;
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
