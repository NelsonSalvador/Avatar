using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformMovment : MonoBehaviour
{
    public Vector3 pos2;
    public float speed;

    Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == new Vector3(0, 0, 0))
        {
            nextPos = pos2;
        }
        if (transform.position == pos2)
        {
            nextPos = new Vector3(0, 0, 0);
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(new Vector3(0, 0, 0), pos2);
    }
}
