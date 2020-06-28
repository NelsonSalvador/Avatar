using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnUI : MonoBehaviour
{
    public GameObject Player;
    public GameObject Text;
    public GameObject[] Enemys;

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

        checkpoint = FindObjectOfType<Checkpoint>();
        Player.transform.position = checkpoint.playerPos;
        gameObject.SetActive(false);
        Text.SetActive(false);
        Player.GetComponent<Shoot>().fire = true;

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