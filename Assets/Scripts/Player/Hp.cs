using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    public float hp = 100;
    public float heightdmgStart = 300;
    public Transform groundCheck;
    public LayerMask GroundLayers;
    public GameObject MainCamera;
    public GameObject Text;
    Text text;

    float time;

    public float inicialY;
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

        if ((oneGround == true) && (inicialY > transform.position.y + heightdmgStart))
        {
            hp = hp - (10);
            text.text = $"-{10}";
            text.enabled = true;
            inicialY = transform.position.y;
        }
        else if (oneGround == true)
        {
            inicialY = transform.position.y;
        }


        if (text.enabled == true)
        {
            time += 1.0f;
            if (time == 30.0f)
            {
                text.enabled = false;
                time = 0.0f;
            }
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
            inicialY = transform.position.y;
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
