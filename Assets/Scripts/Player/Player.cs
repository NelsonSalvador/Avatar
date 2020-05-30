using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float    maxSpeed = 50.0f;
    public float    jumpSpeed = 300.0f;
    public float    jumpMaxTime = 0.1f;
    public bool canMove = true;

    public int      maxJumpCount = 1;


    public Transform groundCheck;
    public LayerMask GroundLayers;

    Rigidbody2D     rb;
    Animator        anim;
    int             jumpsAvailable;

    float jumpTime;
    bool oneGround;

    CapsuleCollider2D capsule;
    BoxCollider2D box;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        capsule = GetComponent<CapsuleCollider2D>();
        box = GetComponent<BoxCollider2D>();

        capsule.isTrigger = false;
        box.isTrigger = true;


        jumpsAvailable = maxJumpCount;
    }

    // Update is called once per frame
    void Update()
    {
        // Movimento em x
        float hAxis = Input.GetAxis("Horizontal");

        Vector2 currentVelocity = rb.velocity;

        if (canMove == true)
            currentVelocity = new Vector2(maxSpeed * hAxis, currentVelocity.y);

        

        Collider2D groundCollision = Physics2D.OverlapCircle(groundCheck.position, 1, GroundLayers);

        oneGround = groundCollision != null;
        if ((oneGround) && (currentVelocity.y <= 0.001))
        {
            jumpsAvailable = maxJumpCount;
        }

        // Salto
        if ((Input.GetButtonDown("Jump")) && (jumpsAvailable > 0) && (canMove == true))
        {
            currentVelocity.y = jumpSpeed;
            rb.gravityScale = 5.0f;

            jumpsAvailable--;

            FindObjectOfType<AudioManager>().Play("Jump");

        }

        // Troca de Coliders
        if (oneGround == false)
        {
            capsule.isTrigger = true;
            box.isTrigger = false;
        }
        else if (oneGround == true)
        {
            capsule.isTrigger = false;
            box.isTrigger = true;
        }



        rb.velocity = currentVelocity;

        anim.SetFloat("AbsVelX", Mathf.Abs(currentVelocity.x));
        anim.SetFloat("velY", currentVelocity.y);
        anim.SetBool("OnGround", oneGround);
        
        if (currentVelocity.x < -0.01f)
        {
            if (transform.right.x > 0)
                transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (currentVelocity.x > 0.01f)
        {
            if (transform.right.x < 0)
                transform.rotation = Quaternion.identity;
        }

    }

    private void FixedUpdate()
    {
        Collider2D groundCollision = Physics2D.OverlapCircle(groundCheck.position, 1, GroundLayers);

        oneGround = groundCollision != null;

        if ((oneGround == false))
        {
            if (rb.gravityScale < 10.0f)
                rb.gravityScale += 0.2f;
            Debug.Log("Entrou");
        }
        else
        {
            rb.gravityScale = 5.0f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheck.position, 1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlataform")
            this.transform.parent = collision.transform;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlataform")
            this.transform.parent = null;
    }
    
}
