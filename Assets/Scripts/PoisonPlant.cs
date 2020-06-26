using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPlant : MonoBehaviour
{
    Animator anim;
    public GameObject pickedUpText;
    bool pickedUp = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp == true)
        {
            anim.SetTrigger("Colected");
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
