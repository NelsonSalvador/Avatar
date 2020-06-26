using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnUI : MonoBehaviour
{
    public GameObject Player;

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

        checkpoint = FindObjectOfType<Checkpoint>();
        Player.transform.position = checkpoint.playerPos;
        gameObject.SetActive(false);

    }
    public void QuitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}