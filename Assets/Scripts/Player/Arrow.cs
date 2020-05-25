using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 20.0f;
    public Rigidbody2D rb;
    public float dmg = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamge(dmg / 2);
        }
    }
}
