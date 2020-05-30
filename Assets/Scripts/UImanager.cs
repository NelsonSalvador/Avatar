using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UImanager : MonoBehaviour
{
    public Image healthBar;
    public Hp playerHp;
    public GameObject Player;
    public GameObject RepawnMenu;
    public GameObject Text;

    public bool meter = false;

    public Image[] killingMeter;

    TextMeshProUGUI TextMesh;
    int imgDel = 2;
    // Start is called before the first frame update
    void Start()
    {
        TextMesh = Text.GetComponent<TextMeshProUGUI>();
        Text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = playerHp.hp / 100;
        if (meter == true)
        {
            killingMeter[imgDel].enabled = false;
            imgDel = imgDel - 1;
            meter = false;
            if (imgDel + 1 == 0)
            {
                
                RepawnMenu.SetActive(true);
                Text.SetActive(true);
                TextMesh.text = "You Killed To Many WildLife !!!";
                Player.SetActive(false);
            }
        }
        
    }
}
