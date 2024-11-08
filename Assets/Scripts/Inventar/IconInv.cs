using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconInv : MonoBehaviour
{
    public Image image;
    public Sprite stok;
    public Inventared inventared;
    public Data data;
    public int index;

    private void FixedUpdate()
    {
        if (data.index.Count > 0) 
        {
            for (int i = 0; i < data.index.Count; i++)
            {
                if (index < data.index.Count)
                {
                    int num = data.index[index];
                    image.sprite = inventared.icon[num];
                }
                else
                {
                    image.sprite = stok;
                }
            }
        }
    }
}
