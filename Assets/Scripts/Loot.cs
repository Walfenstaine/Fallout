using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public int index;
    public Inventared inventared;
    public SpriteRenderer render;
    private void Start()
    {
        render.sprite = inventared.icon[index];
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            Inventar_Mini mini = other.GetComponent<Inventar_Mini>();
            if (mini.inventar.Count < 10) 
            {
                mini.inventar.Add(index);
                mini.Save();
                Destroy(gameObject);
            }
            
        }
    }
}
