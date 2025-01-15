using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using UnityEngine;
using static SaveAndLoad;

public class Cam : MonoBehaviour
{
    public List <Inventar_Mini> perses;
    public GameObject pers;
    public Vector3 pos;
    public static Cam rid { get; set; }
    void Awake()
    {
        if (PlayerPrefs.HasKey("Pers"))
        {
            for (int i = 0; i < PlayerPrefs.GetInt("Pers"); i++)
            {
                GameObject g = Instantiate(pers);
                g.transform.position = transform.position;
                perses.Add(g.GetComponent<Inventar_Mini>());
            }
        }
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
    public void Save() 
    {
        PlayerPrefs.SetInt("Pers", perses.Count);
    }
    public void NewPers() 
    {
        GameObject g = Instantiate(pers);
        perses.Add(g.GetComponent<Inventar_Mini>());
        Save();
    }

    private void FixedUpdate()
    {
       
        for (int i = 0; i < perses.Count; i++) 
        {
            perses[i].index = i;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) 
        {
            pos += new Vector3(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"), 0) * 100 * Time.deltaTime;
        }
        transform.position = Vector3.Lerp(transform.position, pos, 3 * Time.deltaTime);
    }
}
