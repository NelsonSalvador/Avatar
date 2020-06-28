using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

public class MainMenuCamera : MonoBehaviour
{
    public float cameraspeed = 20f;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos.x += cameraspeed * Time.deltaTime;

        transform.position = pos;
    }
}
