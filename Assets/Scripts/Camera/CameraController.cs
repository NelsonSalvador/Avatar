using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform followtarget;
    [SerializeField] Vector3 offset;
    [SerializeField] float feedBackLoopFactor = 0.1f;
    [SerializeField] Rect cameraTrap;

    private Camera myCamera = null;

    public bool cinematic = false;

    // Start is called before the first frame update
    void Start()
    {
        myCamera = GetComponent<Camera>();
        myCamera.orthographicSize = 100;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cinematic == false)
        {
            if (myCamera.orthographicSize < 190)
                myCamera.orthographicSize += 1;

            Vector3 tragetPos = followtarget.position + offset;
            tragetPos.z = transform.position.z;

            Rect rect = GetWorldRect();

            if (tragetPos.x < rect.xMin) rect.xMin = tragetPos.x;
            else if (tragetPos.x > rect.xMax) rect.xMax = tragetPos.x;

            if (tragetPos.y < rect.yMin) rect.yMin = tragetPos.y;
            else if (tragetPos.y > rect.yMax) rect.yMax = tragetPos.y;

            Vector3 movePosition = rect.center;
            movePosition.z = transform.position.z;

            Vector3 delta = movePosition - transform.position;

            transform.position = transform.position + delta * feedBackLoopFactor;
        }
    }
    Rect GetWorldRect()
    {
        Rect rect = cameraTrap;
        rect.position += new Vector2(-rect.width * 0.5f, -rect.height * 0.5f);
        rect.position += new Vector2(transform.position.x, transform.position.y);


        return rect;
    }

    private void OnDrawGizmosSelected()
    {
        Rect newRect = GetWorldRect();
        Gizmos.color = new Color(0, 0.5f, 0.0f, 1.0f);

        Vector3 p1 = new Vector3(newRect.xMin, newRect.yMin, 0);
        Vector3 p2 = new Vector3(newRect.xMax, newRect.yMin, 0);
        Vector3 p3 = new Vector3(newRect.xMax, newRect.yMax, 0);
        Vector3 p4 = new Vector3(newRect.xMin, newRect.yMax, 0);


        Gizmos.DrawLine(p1, p2);
        Gizmos.DrawLine(p2, p3);
        Gizmos.DrawLine(p3, p4);
        Gizmos.DrawLine(p4, p1);

    }
}
