using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEventer : MonoBehaviour
{
    public int weaponNum, bronyaNum;
    public int[] layers;
    public Mesh[] mesh;
    public Mesh[] bronMesh;
    public Material[] bronMat;
    public Material[] material;
    public SkinnedMeshRenderer smr;
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
           weaponsMat.material = material[weaponNum];
           weaponsMesh.mesh = mesh[weaponNum];
        }
        for (int i = 0; i < bronMat.Length; i++)
        {
            smr.material = bronMat[bronyaNum];
            smr.sharedMesh = bronMesh[bronyaNum];

        }
        anim.SetLayerWeight(layers[weaponNum], 1);
    }
}
