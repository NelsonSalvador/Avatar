using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafRotation : MonoBehaviour
{
    public Transform groundCheck;
    public float speed;
    public float angle = 50;
    public bool reversedObject = false;
    public LayerMask GroundLayers;

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
    void Update()
    {
        Collider2D groundCollision = Physics2D.OverlapCircle(groundCheck.position, 1, GroundLayers);

        bool oneGround = groundCollision != null;
        if ((oneGround))
        {
            rotate = true;
            
        }
        else
        {

        }

        if (rotate == true)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, speed * Time.deltaTime);
        }
    }
}
