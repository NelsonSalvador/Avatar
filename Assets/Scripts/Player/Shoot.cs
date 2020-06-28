using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int poisonShots = 0;

    public Image NormalArrow;
    public Image PoisonArrow;

    public TextMeshProUGUI poisonArrowsText;

    Animator anim;

    bool poison = false;
    private int first;

    public bool fire = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        fire = true;
        first = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (first == 0)
        {
            poison = false;
            PoisonArrow.enabled = false;
            NormalArrow.enabled = true;
            first++;
        }
        if(Input.GetButtonDown("Fire1") && fire == true)
        {
            shoot();
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            poison = true;
            PoisonArrow.enabled = true;
            NormalArrow.enabled = false;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            poison = false;
            PoisonArrow.enabled = false;
            NormalArrow.enabled = true;
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
        if (poison == true && poisonShots >= 1)
        {
            poisonShots -= 1;
            poisonArrowsText.text = (poisonShots) + "x";
            bulletPrefab.GetComponent<Arrow>().poisonArrow = true;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        else if (poison == true && poisonShots == 0)
        {

        }
        else
        {            
            bulletPrefab.GetComponent<Arrow>().poisonArrow = false;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        
        fire = false;
        StartCoroutine(timer(0.5f));
    }
}
