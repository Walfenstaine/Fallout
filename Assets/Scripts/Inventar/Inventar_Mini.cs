using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SaveAndLoad;

public class Inventar_Mini : MonoBehaviour
{
    public int index;
    public List<int> inventar;
    private void Awake()
    {
        InvokeRepeating("Loadinventory", 0.5f, 0);
       
    }
    public void Loadinventory() 
    {
        if (PlayerPrefs.HasKey("" + index))
        {
            string globalDataJSON = PlayerPrefs.GetString("" + index);
            MyList loadedList = JsonUtility.FromJson<MyList>(globalDataJSON);
            for (int i = 0; i < loadedList.list.Count; i++)
            {
                inventar.Add(loadedList.list[i]);
            }
        }
    }
    public void Read_Inv() 
    {
        for (int i = 0; i < inventar.Count; i++) 
        {
            Inv_Pers.rid.index.Add(inventar[i]);
        }
        Inv_Pers.rid.InvOn();
    }
    public void Save(int i)
    {
        inventar.Add(i);
        var listInClass = new MyList();
        listInClass.list = inventar;
        var outputString = JsonUtility.ToJson(listInClass);
        PlayerPrefs.SetString(""+index, outputString);
        Debug.Log("Save");
    }
}

