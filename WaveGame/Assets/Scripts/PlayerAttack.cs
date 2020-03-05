using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
   // public Animator camAnim;
    //public Animator playerAnim;
    public float attackRangeX;
    public float attackRangeY;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            // then you can attack
            if (Input.GetKey(KeyCode.Q))
            {
                Debug.Log("Q");
                // camAnim.SetTrigger("shake");
                // playerAnim.SetTrigger("attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    Debug.Log(enemiesToDamage[i].name);
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            else
            {
                timeBtwAttack = startTimeBtwAttack;
                timeBtwAttack -= Time.deltaTime;
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }
}
