using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using static SaveAndLoad;

public class Cam : MonoBehaviour
{
    public List<int> perses;
    public GameObject pers;
    public Vector3 pos;
    public static Cam rid { get; set; }
    void Awake()
    {
        if (PlayerPrefs.HasKey("Pers"))
        {
            string globalDataJSON = PlayerPrefs.GetString("Pers");
            MyList loadedList = JsonUtility.FromJson<MyList>(globalDataJSON);
            for (int i = 0; i < loadedList.list.Count; i++)
            {
                NewPers(loadedList.list[i]);
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

    public void NewPers(int name) 
    {
        perses.Add(name);
        var listInClass = new MyList();
        listInClass.list = perses;
        var outputString = JsonUtility.ToJson(listInClass);
        PlayerPrefs.SetString("Pers", outputString);
        GameObject p = Instantiate(pers);
        p.transform.position = transform.position;
        p.name = "" + name;
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
