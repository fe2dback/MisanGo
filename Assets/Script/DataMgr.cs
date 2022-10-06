using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character
{
    Man, Girl
}

public class DataMgr : MonoBehaviour
{
    public static DataMgr instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public Character currentCharacter;
    public bool startCheck = false;
    public Vector3 playerTp;
}