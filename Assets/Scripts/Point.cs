using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Point : MonoBehaviour
{
    public bool isPlayer;
    public Animator anim;
    public static event Action<Vector3> pos;

    float timer;

    void OnTouch() 
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                isPlayer = true;
            }
            else
            {
                if (hit.collider.tag == "Grund")
                {
                    if (isPlayer)
                    {
                        anim.SetTrigger("Point");
                        transform.position = hit.point;
                        pos.Invoke(hit.point);
                        isPlayer = false;
                    }

                }
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            timer = Time.time + 0.1f;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (timer > Time.time) 
            {
                OnTouch();
            }
        }
    }
}
