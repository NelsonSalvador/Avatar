using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 20.0f;
    public Rigidbody2D rb;
    public float dmg = 50.0f;

    public bool poisonArrow = false;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    IEnumerator destroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
    IEnumerator endStun(float time, int enemydmg, DamageTriger dmgTriger, Rigidbody2D enemyRb, GameObject follow, Animator anim)
    {
        yield return new WaitForSeconds(time);
        dmgTriger.DamgeDone = enemydmg;
        enemyRb.constraints = ~RigidbodyConstraints2D.FreezePositionX;
        follow.SetActive(true);
        anim.SetBool("Sleeping", false);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            DamageTriger dmgTriger = enemy.GetComponentInChildren<DamageTriger>();
            GameObject follow = enemy.transform.GetChild(1).gameObject;
            Animator anim = enemy.GetComponent<Animator>();
            

            Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
            int enemydmg;
            if (poisonArrow == false)
            {
                
                enemy.TakeDamge(dmg);
                StartCoroutine(destroy(0.1f));
            }
            else
            {
                enemydmg = dmgTriger.DamgeDone;
                dmgTriger.DamgeDone = 0;
                enemyRb.constraints = RigidbodyConstraints2D.FreezePositionX;
                follow.SetActive(false);
                anim.SetBool("Sleeping", true);
                gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
                StartCoroutine(endStun(10.0f, enemydmg, dmgTriger, enemyRb, follow, anim));
            }
        }
        else
            StartCoroutine(destroy(1.5f));
    }
}
