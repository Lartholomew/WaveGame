using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCode : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5;
    public bool isMainPlayer;
    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMainPlayer)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Time.deltaTime * +speed, 0, 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Time.deltaTime * -speed, 0, 0);
            }
            /*
            {
                
                Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
                transform.position += movement * Time.deltaTime * moveSpeed;
            }

            */

        }
    }
}

