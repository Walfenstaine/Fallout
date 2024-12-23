using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Vector3 pos;
    public static Cam rid { get; set; }
    void Awake()
    {
        if (rid == null)
        {
            rid = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void OnDestroy()
    {
        rid = null;
    }
    private void Start()
    {
        pos = transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, pos, 3 * Time.deltaTime);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) 
        {
            pos += new Vector3(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"), 0) * 30 * Time.deltaTime;
        }
    }
}
