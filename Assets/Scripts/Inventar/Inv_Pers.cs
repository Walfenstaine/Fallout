using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inv_Pers : MonoBehaviour
{
    public Image[] image;
    public Sprite stok;
    public Inventared inventared;
    public Data data;
    public int index;

    private void FixedUpdate()
    {
        if (data.index.Count > 0)
        {
            for (int i = 0; i < image.Length; i++)
            {
                if (index < data.index.Count)
                {
                    int num = data.index[index];
                }
                else
                {

                }
            }
        }
    }
}
