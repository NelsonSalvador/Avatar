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
    public GameObject Text;
    Text text;
    public float AirTimeDmgStart = 50.0f;

    float time;
    public float jumpTime;
    // Start is called before the first frame update
    void Start()
    {
        text = Text.GetComponent<Text>();
        text.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider2D groundCollision = Physics2D.OverlapCircle(groundCheck.position, 1, GroundLayers);

        bool oneGround = groundCollision != null;

        if (text.enabled == true)
        {
            time += 1.0f;
            if (time == 30.0f)
            {
                text.enabled = false;
                time = 0.0f;
            }
            
        }

        if ( (oneGround == false) )
        {
            jumpTime += 1.0f;
        }
        else if (oneGround == true)
        {
            if (jumpTime > AirTimeDmgStart)
            {
                hp = hp - (0.2f * jumpTime);
                text.text = $"-{0.2f * jumpTime}";
                text.enabled = true;
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
   /* private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Poison")
        {
            hp = hp - 50;
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hp = hp - 20;
            text.text = "-10";
            text.enabled = true;
        }
    }
}
