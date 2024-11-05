using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pers : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator anim;
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
        agent.destination = target;
    }
    private void FixedUpdate()
    {
        if (agent.velocity != Vector3.zero)
        {
            anim.SetBool("Run", true);
            anim.SetFloat("Speed", agent.velocity.magnitude/2);
        }
        else 
        {
            anim.SetBool("Run", false);
        }
    }
}
