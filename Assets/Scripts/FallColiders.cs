using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FallColiders : MonoBehaviour
{
    public GameObject TextDeath;
    public GameObject repawnMenu;
    TextMeshProUGUI TextMesh;
    
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        TextMesh = TextDeath.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            repawnMenu.SetActive(true);
            Player.SetActive(false);

            TextDeath.SetActive(true);
            TextMesh.text = "You Died !!!";
        }
    }
}
