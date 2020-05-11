using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Camera1;
    public Vector3 nextPos;
    public float speed = 50.0f;

    bool reverse = false;
    bool count = false;
    // Start is called before the first frame update
    void Start()
    {
        Camera1.SetActive(false);
        MainCamera.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((reverse == false) && (Camera1.active == true))
        {
            Camera1.transform.position = Vector3.MoveTowards(Camera1.transform.position, nextPos, speed * Time.deltaTime);
            if (Camera1.transform.position == nextPos)
                reverse = true;
        }
        else if ((reverse == true) && (Camera1.active == true))
        {
            Camera1.transform.position = Vector3.MoveTowards(Camera1.transform.position, MainCamera.transform.position, (speed * Time.deltaTime) * 4);
            
        }
        if ((Camera1.transform.position == MainCamera.transform.position) && (reverse == true))
        {
            Camera1.SetActive(false);
            MainCamera.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (count == false)
            {
                Camera1.SetActive(true);
                MainCamera.SetActive(false);
            }
            count = true;
        }
    }
}
