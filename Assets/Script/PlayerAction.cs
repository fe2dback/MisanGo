using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour
{
    public float Speed;

    Rigidbody2D rb2d;
    Animator anim;
    float h;
    float v;
    bool isHorizonMove;
    public int SceneNumber;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SceneNumber = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        // Move Value
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        // Check Button Down & Up
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        // Check Horizontal Move
        if(hDown)
        {
            isHorizonMove = true;
        }
        else if(vDown)
        {
            isHorizonMove = false;
        }
        else if(hUp || vUp)
        {
            isHorizonMove = h != 0;
        }

        // Animation
        if(anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if(anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            anim.SetBool("isChange", false);
        }

        if(rb2d.transform.position.x > 9 && SceneNumber == 1)
        {
            DataMgr.instance.playerTp = new Vector3((rb2d.transform.position.x * -1) + 1, rb2d.transform.position.y);
            SceneManager.LoadScene("hallway1_Scene");
        }
        else if(rb2d.transform.position.x > 9 && SceneNumber == 2)
        {
            DataMgr.instance.playerTp = new Vector3((rb2d.transform.position.x * -1) + 1, rb2d.transform.position.y);
            SceneManager.LoadScene("hallway2_Scene");
        }
        else if(rb2d.transform.position.x < -9 && SceneNumber == 2)
        {
            DataMgr.instance.playerTp = new Vector3((rb2d.transform.position.x * -1) - 1, rb2d.transform.position.y);
            SceneManager.LoadScene("PlayScene");
        }
        else if (rb2d.transform.position.x > 9 && SceneNumber == 3)
        {
            
        }
        else if (rb2d.transform.position.x < -9 && SceneNumber == 3)
        {
            DataMgr.instance.playerTp = new Vector3((rb2d.transform.position.x * -1) -1, rb2d.transform.position.y);
            SceneManager.LoadScene("hallway1_Scene");
        }
    }

    private void FixedUpdate()
    {
        // Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rb2d.velocity = moveVec * Speed;
    }
}
