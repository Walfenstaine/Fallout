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

    public void OnWeapon(int num) 
    {
        weaponNum = num;
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < mesh.Length; i++) 
        {
            weaponsMesh.mesh = mesh[weaponNum];
            weaponsMat.material = material[weaponNum];
            
        }
        if (weaponNum == 0)
        {
            anim.SetLayerWeight(1, 0);
            anim.SetLayerWeight(0, 0);
        }
        else
        {
            anim.SetLayerWeight(layers[weaponNum], 1);
        }
    }
}
