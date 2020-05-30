using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Hp : MonoBehaviour
{
    public float hp = 100;
    public float heightdmgStart = 300;
    public Transform groundCheck;
    public LayerMask GroundLayers;
    public GameObject MainCamera;
    public GameObject TextDmg;
    public GameObject TextDeath;

    public GameObject repawnMenu;
    Text text;

    TextMeshProUGUI TextMesh;

    float time;

    public float inicialY;
    // Start is called before the first frame update
    void Start()
    {
        text = TextDmg.GetComponent<Text>();
        TextMesh = TextDeath.GetComponent<TextMeshProUGUI>();
        text.enabled = false;
        repawnMenu.SetActive(false);
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

        // Respawn menu (Player Dies)
        if (hp <= 1.0f)
        {
            repawnMenu.SetActive(true);
            gameObject.SetActive(false);

            TextDeath.SetActive(true);
            TextMesh.text = "You Died !!!";
        }


    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Leaf")
        {
            inicialY = transform.position.y;
        }
    }


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
