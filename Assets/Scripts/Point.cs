using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Point : MonoBehaviour
{

    public Animator anim;
    public static event Action<Vector3> pos;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Grund")
                {
                    anim.SetTrigger("Point");
                    transform.position = hit.point;
                    pos.Invoke(hit.point);
                }
            }
        }
    }
}
