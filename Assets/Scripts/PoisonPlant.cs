using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PoisonPlant : MonoBehaviour
{
    Animator anim;
    public GameObject pickedUpText;
    public TextMeshProUGUI poisonArrowsText;
    bool pickedUp = false;
    int counter = 0;
    int nPoisonArrows;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        poisonArrowsText.text = (nPoisonArrows + "x");
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp == true && counter == 0)
        {
            nPoisonArrows = player.GetComponent<Shoot>().poisonShots;
            anim.SetTrigger("Colected");
            poisonArrowsText.text = (nPoisonArrows + 1) + "x";
            player.GetComponent<Shoot>().poisonShots = player.GetComponent<Shoot>().poisonShots + 1;
            counter = 1;
        }
    }

   private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E))
            {
                pickedUp = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pickedUpText.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pickedUpText.SetActive(true);
        }
    }
}
