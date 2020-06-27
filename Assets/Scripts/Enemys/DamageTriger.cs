using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTriger : MonoBehaviour
{
    public GameObject thisEnemy;
    public GameObject player;
    public int DamgeDone = 20;

    Hp hp;
    Enemy enemy;
    Animator anim;

    bool inDamgeZone = false;
    bool waitTimeDmg = true;
    // Start is called before the first frame update
    void Start()
    {
        hp = player.GetComponent<Hp>();
        enemy = thisEnemy.GetComponent<Enemy>();
        anim = thisEnemy.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inDamgeZone == true && waitTimeDmg == true)
        {
            StartCoroutine(dealDamge(0.5f));
            waitTimeDmg = false;
        }
    }

    IEnumerator dealDamge(float time)
    {
        yield return new WaitForSeconds(time);
        anim.SetTrigger("Atack");
        hp.hp -= DamgeDone;
        waitTimeDmg = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            anim.SetTrigger("Atack");
        }
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inDamgeZone = true;
            enemy.sleping = true;
        }
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enemy.sleping = false;
            inDamgeZone = false;
        }
    }
}
