using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed = 50.0f;
    public float jumpSpeed = 300.0f;
    public float jumpMaxTime = 0.1f;

    public Transform groundCheck;
    public LayerMask GroundLayers;

    Rigidbody2D rb;

    float jumpTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movimento em x
        float hAxis = Input.GetAxis("Horizontal");

        Vector2 currentVelocity = rb.velocity;

        currentVelocity = new Vector2(maxSpeed * hAxis, currentVelocity.y);



        Collider2D groundCollision = Physics2D.OverlapCircle(groundCheck.position, 5, GroundLayers);

        bool oneGround = groundCollision != null;

        // Salto
        if ((Input.GetButtonDown("Jump")) && (oneGround))
        {
            currentVelocity.y = jumpSpeed;
            rb.gravityScale = 0.0f;

            jumpTime = Time.time;
        }
        else if ((Input.GetButtonDown("Jump")) && ((Time.time - jumpTime) < jumpMaxTime))
        {
            
        }
        else
        {
            rb.gravityScale = 5.0f;
        }

        rb.velocity = currentVelocity;

    }
}
