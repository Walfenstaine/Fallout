using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Inv_Pers : MonoBehaviour
{
    public Inventared inv_Icon;
    public List<int> index;
    public Image[] image;
    public Image fon;
    public UnityEvent<bool> clic;
    public static Inv_Pers rid { get; set; }
    void Awake()
    {
        InvOff();
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
    public void InvOn() 
    {
        clic.Invoke(true);
        fon.enabled = true;
        for (int i = 0; i < index.Count; i++)
        {
            image[i].sprite = inv_Icon.icon[index[i]];
        }
    }
    public void InvOff() 
    {
        clic.Invoke(false);
        fon.enabled = false;
        index.Clear();
    }

    private void FixedUpdate()
    {
        
    }
}
