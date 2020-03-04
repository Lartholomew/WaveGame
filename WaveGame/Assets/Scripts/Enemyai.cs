using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemyai : MonoBehaviour
{
    public bool dirRight = true;
    public float speed = 2.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

    }
    void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("FirstLevel"); 
        }
    }
}
