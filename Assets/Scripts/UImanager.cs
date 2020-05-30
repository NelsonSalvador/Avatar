using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UImanager : MonoBehaviour
{
    public Image healthBar;
    public Hp playerHp;

    public bool meter = false;

    public Image[] killingMeter;

    int imgDel = 2;
    // Start is called before the first frame update
    void Start()
    {
        
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
    }
}
