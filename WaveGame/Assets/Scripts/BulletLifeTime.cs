using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLifeTime : MonoBehaviour
{
    Rigidbody rb;
    public float bulletLifeTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.right/4;
        bulletLifeTime -= Time.deltaTime;
        if (bulletLifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);

        }
        else if (other.gameObject.tag == "Enemy")

        {
            Debug.Log("omg hit");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        
    }
}
