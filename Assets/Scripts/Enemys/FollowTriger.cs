using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTriger : MonoBehaviour
{
    public GameObject thisEnemy;
    Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = thisEnemy.GetComponent<Enemy>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enemy.follow = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enemy.follow = false;
        }
    }
}
