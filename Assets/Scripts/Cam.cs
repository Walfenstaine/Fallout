using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) 
        {
            pos += new Vector3(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"), 0) * 30 * Time.deltaTime;
        }
    }
}
