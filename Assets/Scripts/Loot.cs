using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public int index;
    public Inventared inventared;
    public Data data;
    public SpriteRenderer render;
    private void Start()
    {
        render.sprite = inventared.icon[index];
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            data.index.Add(index);
            Destroy(gameObject);
        }
    }
}
