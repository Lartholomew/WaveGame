using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Enemyai ai;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
          //  Debug.Log("Enemy Turning");
            if (ai.dirRight == true)

                ai.dirRight = false;
            else
                ai.dirRight = true;

        }
    }
}
