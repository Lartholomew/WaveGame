using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    private float dazedTime;
    public float startDazedTime;

    public bool dirRight = true;
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (dazedTime <= 0)
        {
            speed = 5;
        }

        else 
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }


        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (dirRight)
        {
           transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        else
        {
           transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }
    }
    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        health -= damage;
        Debug.Log("damage TAKEN !");
    }
}

