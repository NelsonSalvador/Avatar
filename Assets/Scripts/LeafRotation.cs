using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafRotation : MonoBehaviour
{
    public float speed;
    public float angle = 50;
    public bool reversedObject = false;

    Quaternion rot;
    float angleReversed;
    bool rotate = false;
    float acelaration;

    // Start is called before the first frame update
    void Start()
    {
        if (reversedObject == false)
            angleReversed = 0;
        else
            angleReversed = 180;

        acelaration = speed;

        rot = Quaternion.Euler(0, angleReversed, angle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotate == true)
        {
            speed += 2;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, speed * Time.deltaTime);
        }
        else if (rotate == false)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, angleReversed, 0), 20 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            speed = acelaration;
            rotate = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            rotate = false;
        }
    }
}
