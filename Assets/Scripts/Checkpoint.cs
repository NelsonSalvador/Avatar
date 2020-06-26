using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject Player;
    public Vector3 playerPos;
    UImanager uImanager;
  
    // Start is called before the first frame update
    void Start()
    {
        uImanager = FindObjectOfType<UImanager>();
        playerPos = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerPos = Player.transform.position;
            Player.GetComponent<Hp>().hp = 100;
            uImanager.killingMeter[0].enabled = true;
            uImanager.killingMeter[1].enabled = true;
            uImanager.killingMeter[2].enabled = true;
            uImanager.imgDel = 2;
        }
    }
}
