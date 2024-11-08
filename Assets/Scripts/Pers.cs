using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pers : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator anim;
    public bool active;
    private void OnEnable()
    {
        Point.pos += Ontarget;
    }
    private void OnDisable()
    {
        Point.pos -= Ontarget;
    }
    void Ontarget(Vector3 target) 
    {
        if (active) 
        {
            agent.destination = target;
        }
    }
    private void FixedUpdate()
    {
        if (agent.velocity != Vector3.zero)
        {
            active = false;
            anim.SetBool("Run", true);
            anim.SetFloat("Speed", agent.velocity.magnitude/2);
        }
        else 
        {
            anim.SetBool("Run", false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == this.GetComponent<BoxCollider>())
                {
                    active = true;
                }
                else 
                {
                    if (hit.collider.tag != "Grund") 
                    {
                        active = false;
                    }
                }
            }
        }
    }
}
