using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour
{
    public float Speed;
    //public TalkManager manager;

    Rigidbody2D rb2d;
    Animator anim;
    Vector3 dirVec;
    GameObject scanObject;
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
        h = GameManager.instance.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = GameManager.instance.isAction ? 0 : Input.GetAxisRaw("Vertical");

        // Check Button Down & Up
        bool hDown = GameManager.instance.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = GameManager.instance.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = GameManager.instance.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = GameManager.instance.isAction ? false : Input.GetButtonUp("Vertical");

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

        // Direction
        if(vDown && v == 1)
        {
            dirVec = Vector3.up;
        }
        else if(vDown && v == -1)
        {
            dirVec = Vector3.down;
        }
        else if (hDown && h == -1)
        {
            dirVec = Vector3.left;
        }
        else if (hDown && h == 1)
        {
            dirVec = Vector3.right;
        }

        // Scan Object
        if(Input.GetButtonDown("Jump") && scanObject != null)
        {
            GameManager.instance.Action(scanObject);
        }



        // SceneMove
        if (rb2d.transform.position.x > 9)
        {
            DataMgr.instance.playerTp = new Vector3((rb2d.transform.position.x * -1) + 1, rb2d.transform.position.y);
            SceneManager.LoadScene(SceneNumber + 1);
        }
        else if(rb2d.transform.position.x < -9)
        {
            DataMgr.instance.playerTp = new Vector3((rb2d.transform.position.x * -1) - 1, rb2d.transform.position.y);
            SceneManager.LoadScene(SceneNumber - 1);
        }
        
    }

    private void FixedUpdate()
    {
        // Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rb2d.velocity = moveVec * Speed;

        // Ray
        Debug.DrawRay(rb2d.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rb2d.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if(rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }
}
