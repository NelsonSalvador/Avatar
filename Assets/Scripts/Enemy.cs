using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public Transform groundCheck;
    public LayerMask GroundLayers;
    public float Speed = 20;

    bool follow = false;
    float AISpeed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        if (follow == false)
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

        



        if (follow == true && oneWall == false)
        {
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
    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            follow = true;
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
