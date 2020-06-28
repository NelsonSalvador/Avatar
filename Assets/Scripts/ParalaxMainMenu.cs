using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class ParalaxMainMenu : MonoBehaviour
{
    private float startpos;
    public GameObject cam;
    public float parallaxEffect;

    private void Start()
    {
        startpos = transform.position.x;
    }

    private void FixedUpdate()
    {   
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
    }
}
