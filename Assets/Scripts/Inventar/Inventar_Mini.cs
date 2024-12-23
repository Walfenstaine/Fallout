using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SaveAndLoad;

public class Inventar_Mini : MonoBehaviour
{
    public List<int> inventar;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(gameObject.name))
        {
            string globalDataJSON = PlayerPrefs.GetString(gameObject.name);
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
    public void Save()
    {
        var listInClass = new MyList();
        listInClass.list = inventar;
        var outputString = JsonUtility.ToJson(listInClass);
        PlayerPrefs.SetString(gameObject.name, outputString);
        Debug.Log("Save");
    }
}

