using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEventer : MonoBehaviour
{
    public int weaponNum;
    public int[] layers;
    public Mesh[] mesh;
    public Material[] material;
    public MeshFilter weaponsMesh;
    public MeshRenderer weaponsMat;
    public Animator anim;

    private void FixedUpdate()
    {
        for (int i = 0; i < mesh.Length; i++) 
        {
            weaponsMesh.mesh = mesh[weaponNum];
            weaponsMat.material = material[weaponNum];
            if (i == weaponNum)
            {
                anim.SetLayerWeight(layers[i], 1);
            }
            else 
            {
                anim.SetLayerWeight(layers[i], 0);
            }
        }
    }
}
