using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{/*
    [SerializeField] Transform followtarget;
    [SerializeField] Vector3 offset;
    [SerializeField] float feedBackLoopFactor = 0.1f;
    [SerializeField] Rect cameraTrap;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 tragetPos = followtarget.position + offset;
        tragetPos.z = transform.position.z;

        Rect rect = GetWorldRect();

        if (tragetPos.x < rect.xMin) rect.xMin = tragetPos.x;
        else if (tragetPos.x > rect.xMin) rect.xMin - tragetPos.x;

        if (tragetPos.y < rect.yMin) rect.yMin = tragetPos.y;
        else if (tragetPos.y > rect.yMin) rect.yMin - tragetPos.y;


        //Vector3 delta = tragetPos - transform.position;

        //transform.position = transform.position + delta * feedBackLoopFactor;

        transform.position - transform.position;
    }
    Rect GetWorldRect()
    {
        Rect rect = cameraTrap;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 0.5f, 0.0f, 1.0f);

        Vector3 p1 = new Vector3(cameraTrap.xMin + transform.position.x, cameraTrap.yMin + transform.position.y, 0);
        Vector3 p2 = new Vector3(cameraTrap.xMax + transform.position.x, cameraTrap.yMin + transform.position.y, 0);
        Vector3 p3 = new Vector3(cameraTrap.xMax + transform.position.x, cameraTrap.yMax + transform.position.y, 0);
        Vector3 p4 = new Vector3(cameraTrap.xMin + transform.position.x, cameraTrap.yMax + transform.position.y, 0);


       // Gizmos.
    }*/
}
