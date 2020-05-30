using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;

    public UImanager ui;
    public bool sleping = false;
    [SerializeField] LayerMask layer;

    public Transform groundCheck;
    public LayerMask GroundLayers;
    public float Speed = 20;

    Animator anim;


    bool follow = false;
    float AISpeed;
    Rigidbody2D rb;

    ContactFilter2D layerCol;

    public float health = 100.0f;

    public void TakeDamge (float damage)
    {
        health -= damage;
        FindObjectOfType<AudioManager>().Play("Hit");

        if (health <= 0)
        {
            Destroy(gameObject);
            ui.meter = true;
            FindObjectOfType<AudioManager>().Play("EnemyKill");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        layerCol = new ContactFilter2D();
        layerCol.SetLayerMask(layer);

        AISpeed = Speed;
    }

    private void Update()
    {
        
        Collider2D WallCollision = Physics2D.OverlapCircle(groundCheck.position, 1, GroundLayers);

        bool oneWall = WallCollision != null;
        
        Vector2 currentVelocity = rb.velocity;

        if ((oneWall == true) && (follow == false))
        {
            AISpeed = -AISpeed;
        }

        if (follow == false && sleping == false)
            currentVelocity = new Vector2( (AISpeed) / 2, currentVelocity.y);

        rb.velocity = currentVelocity;
        
        if ((currentVelocity.x < 0.0f) && (follow == false))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }
        else if ((currentVelocity.x > 0.0f) && (follow == false))
        {
            transform.rotation = Quaternion.identity;
            
        }

        if (follow == true && oneWall == false && sleping == false)
        {
            anim.SetFloat("AbsVelX", Mathf.Abs(10));
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.transform.position.x, 
                transform.position.y, 0), Speed * Time.deltaTime);

            if (Player.transform.position.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (Player.transform.position.x > transform.position.x)
            {
                transform.rotation = Quaternion.identity;
            }
        }
        else
        {
            anim.SetFloat("AbsVelX", Mathf.Abs(currentVelocity.x));
        }

    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            follow = true;
            anim.SetTrigger("teste");
            sleping = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sleping = true;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sleping = false;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            follow = false;
        }
    }
}
