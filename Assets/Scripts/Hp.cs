using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    public float hp = 100;
    public Transform groundCheck;
    public LayerMask GroundLayers;
    public GameObject MainCamera;

    public float AirTimeDmgStart = 50.0f;
 

    public float jumpTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider2D groundCollision = Physics2D.OverlapCircle(groundCheck.position, 1, GroundLayers);

        bool oneGround = groundCollision != null;

        if ( (oneGround == false) )
        {
            jumpTime += 1.0f;
            
        }
        else if (oneGround == true)
        {
            if (jumpTime > AirTimeDmgStart)
            {
                hp = hp - (0.2f * jumpTime);
            }
            jumpTime = 0;
        }

        if (jumpTime == 100.0f)
        {
            hp = 0;
            jumpTime = 0;
        }

        if (hp <= 1.0f)
        {
            transform.position = new Vector3(-723, 187, 0);
            MainCamera.transform.position = new Vector3(-670, 127, -10);
            hp = 100;
        }


    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Leaf")
        {
            jumpTime = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Poison")
        {
            hp = hp - 50;
        }
    }
}
