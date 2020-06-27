using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Collections;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (poisonArrow == false)
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                enemy.TakeDamge(dmg);
                StartCoroutine(destroy(0.1f));
            }
            else
            {
                Debug.Log("SLEEP!!!");
            }
        }
        else
            StartCoroutine(destroy(0.5f));
    }
}
