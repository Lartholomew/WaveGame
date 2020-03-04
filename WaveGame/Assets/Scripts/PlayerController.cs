using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float speed = 5;
    public bool isMainPlayer;
    public float respawnHeight = -20;
    public bool pauseTime;
    bool onGround;
    int jumpHeight = 350;
    bool canDoubleJump;
    int doubleJumpHeight = 250;
    bool inAir;
    public Transform BulletSpawnerRight; // where the bullet is spawned
    public Transform BulletSpawnerLeft;
    public GameObject Bullet; // item that we spawn
    public GameObject[] firedBullets = new GameObject[50];
    bool usingSword = false;
    bool usingBlaster = true;
    bool facingRight = true;
    bool facingLeft = false;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        
}

    // Update is called once per frame
    void Update()
    {
        if (isMainPlayer)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                facingRight = true;
                facingLeft = false;
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                facingLeft = true;
                facingRight = false;
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
        }
        if (usingBlaster == true && Input.GetKeyUp(KeyCode.LeftControl))
        {
            usingSword = true;
            usingBlaster = false;
            Debug.Log("Switched to sword");
        }

        else if (usingSword == true && Input.GetKeyUp(KeyCode.LeftControl))
        { 
            usingBlaster = true;
            usingSword = false;
            Debug.Log("Switched to blaster");
        }

        if (facingRight == true && usingBlaster == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            for (int i = 0; i < firedBullets.Length; i++)
            {
                if (firedBullets[i] == null)
                {
                    firedBullets[i] = Instantiate(Bullet, BulletSpawnerRight.transform.position, BulletSpawnerRight.transform.rotation);
                    break;
                }
            }
        }
        else if (facingLeft == true && usingBlaster == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            for (int i = 0; i < firedBullets.Length; i++)
            {
                if (firedBullets[i] == null)
                {
                    firedBullets[i] = Instantiate(Bullet, BulletSpawnerLeft.transform.position, BulletSpawnerLeft.transform.rotation);
                    break;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump == true && inAir == true)
        {
            canDoubleJump = false;
            rb.AddForce(0, doubleJumpHeight, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(0, jumpHeight, 0);
           // transform.Translate(0, jumpHeight * Time.deltaTime, 0);
            onGround = false;
            canDoubleJump = true;
            inAir = true;
        }
        
        
        if (gameObject.transform.position.y <= respawnHeight)
        {

            gameObject.transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            SceneManager.LoadScene("FirstLevel");
        }

        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseTime == false)
            {
                Time.timeScale = 0;
                pauseTime = true;
            }
            else if (pauseTime == true)
            {
                Time.timeScale = 1;
                pauseTime = false;
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            onGround = true;
            inAir = false;
        }
    }
}
