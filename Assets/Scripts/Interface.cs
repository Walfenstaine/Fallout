using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using static SaveAndLoad;

public class Interface : MonoBehaviour
{
    public UnityEvent[] sumer;
    public static Interface rid { get; set; }
    void Awake()
    {
        if (!PlayerPrefs.HasKey("Pers"))
        {
            if (Cam.rid)
            {
                Cam.rid.NewPers();
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

    public void Sum(int index)
    {
        sumer[index].Invoke();
    }
}
