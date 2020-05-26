using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public float paralaxEfectMult = .5f;

    private Transform cameraTransform;
    private Vector3 lastCameraPos;
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPos = cameraTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 deltaMov = cameraTransform.position - lastCameraPos;


        transform.position += deltaMov * paralaxEfectMult;
        lastCameraPos = cameraTransform.position;
    }
}
