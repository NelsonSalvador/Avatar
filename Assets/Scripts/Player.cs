using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float    maxSpeed = 50.0f;
    public float    jumpSpeed = 300.0f;
    public float    jumpMaxTime = 0.1f;

    public int      maxJumpCount = 1;

    public Transform groundCheck;
    public LayerMask GroundLayers;

    Rigidbody2D     rb;
    Animator        anim;
    int             jumpsAvailable;

    float jumpTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        jumpsAvailable = maxJumpCount;
    }

    // Update is called once per frame
    void Update()
    {
        // Movimento em x
        float hAxis = Input.GetAxis("Horizontal");

        Vector2 currentVelocity = rb.velocity;

        currentVelocity = new Vector2(maxSpeed * hAxis, currentVelocity.y);



        Collider2D groundCollision = Physics2D.OverlapCircle(groundCheck.position, 1, GroundLayers);

        bool oneGround = groundCollision != null;
        if ((oneGround) && (currentVelocity.y <= 0.001))
        {
            jumpsAvailable = maxJumpCount;
        }

        // Salto
        if ((Input.GetButtonDown("Jump")) && (jumpsAvailable > 0))
        {
            currentVelocity.y = jumpSpeed;
            rb.gravityScale = 0.0f;

            jumpTime = Time.time;

            jumpsAvailable--;
        }
        else if ((Input.GetButtonDown("Jump")) && ((Time.time - jumpTime) < jumpMaxTime))
        {
            
        }
        else
        {
            rb.gravityScale = 5.0f;
        }

        rb.velocity = currentVelocity;

        anim.SetFloat("AbsVelX", Mathf.Abs(currentVelocity.x));
        
        if (currentVelocity.x < -0.5f)
        {
            if (transform.right.x > 0)
                transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (currentVelocity.x > 0.5f)
        {
            if (transform.right.x < 0)
                transform.rotation = Quaternion.identity;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheck.position, 1);
    }
}
