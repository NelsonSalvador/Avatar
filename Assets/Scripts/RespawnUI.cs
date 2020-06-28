using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RespawnUI : MonoBehaviour
{
    public GameObject Player;
    public GameObject Text;
    public GameObject[] Enemys;
    public GameObject[] Plants;
    public TextMeshProUGUI poisonArrowsText;

    public int poisonArrows = 0;

    Checkpoint checkpoint;
    UImanager uImanager;
    public void PlayGame()
    {
        uImanager = FindObjectOfType<UImanager>();
        Player.GetComponent<Hp>().hp = 100;
        uImanager.killingMeter[0].enabled = true;
        uImanager.killingMeter[1].enabled = true;
        uImanager.killingMeter[2].enabled = true;
        uImanager.imgDel = 2;

        Player.SetActive(true);

        
        

        foreach (GameObject x in Enemys)
        {
            x.SetActive(true);
        }

        foreach (GameObject x in Plants)
        {
            x.GetComponent<PoisonPlant>().pickedUp = false;
            x.GetComponent<PoisonPlant>().counter = 0;
        }

        checkpoint = FindObjectOfType<Checkpoint>();
        Player.transform.position = checkpoint.playerPos;
        gameObject.SetActive(false);
        Text.SetActive(false);
        Player.GetComponent<Shoot>().fire = true;

        Player.GetComponent<Shoot>().poisonShots = poisonArrows;
        poisonArrowsText.text = poisonArrows + "x";

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}