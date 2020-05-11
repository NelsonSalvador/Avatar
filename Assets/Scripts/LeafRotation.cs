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

    // Start is called before the first frame update
    void Start()
    {
        if (reversedObject == false)
            angleReversed = 0;
        else
            angleReversed = 180;

        rot = Quaternion.Euler(0, angleReversed, angle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, speed * Time.deltaTime);
        }
    }
}
