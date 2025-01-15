using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pers : MonoBehaviour
{
    public Transform butons;
    public NavMeshAgent agent;
    public Animator anim;
    public bool active;
    float timer = 0;
    private void OnEnable()
    {
        agent.avoidancePriority = Random.Range(0,99);
        active = true;
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
    public void Deactive() 
    {
        active = false;
    }
    private void FixedUpdate()
    {
        butons.gameObject.SetActive(active);
        butons.eulerAngles = new Vector3(0,180,0);
        if (agent.enabled) 
        {
            if (agent.velocity.magnitude > 0.7f)
            {
                active = false;
                anim.SetBool("Run", true);
                anim.SetFloat("Speed", agent.velocity.magnitude / agent.speed);
            }
            else
            {
                anim.SetBool("Run", false);
            }
        }
        else
        {
            agent.enabled = true;
        }
    }

    void Ontouch() 
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == this.GetComponent<BoxCollider>())
            {
                Cam.rid.pos = new Vector3(transform.position.x, transform.position.y, Cam.rid.transform.position.z);
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
                Ontouch();
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            active = false;
        }
    }
}
