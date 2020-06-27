using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int poisonShots = 0;

    Animator anim;

    public bool fire = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        fire = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetButtonDown("Fire1") && fire == true)
        {
            shoot();
        }
    }

    IEnumerator timer(float time)
    {
        yield return new WaitForSeconds(time);
        fire = true;
    }

    void shoot ()
    {
        anim.SetTrigger("Atack");
        FindObjectOfType<AudioManager>().Play("Shoot");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        fire = false;
        StartCoroutine(timer(0.5f));
    }
}
