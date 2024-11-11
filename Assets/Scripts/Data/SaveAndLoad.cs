using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndLoad : MonoBehaviour
{
    public Data data;
    public class MyList
    {
        public List<int> list;
    }
    public void MaineMenue()
    {
        data.index.Clear();
        SceneManager.LoadScene("Menue");
    }
    public void Exit()
    {
        Save();
        Application.Quit();
    }
    public void Resed()
    {
        data.index.RemoveAll(data.index.Contains);
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Scene1");
    }
    public void Save() 
    {
        var listInClass = new MyList();
        listInClass.list = data.index;
        var outputString = JsonUtility.ToJson(listInClass);
        PlayerPrefs.SetString("Predmets", outputString);
    }

    public void Load() 
    {
        if (PlayerPrefs.HasKey("Predmets"))
        {
            string globalDataJSON = PlayerPrefs.GetString("Predmets");
            MyList loadedList = JsonUtility.FromJson<MyList>(globalDataJSON);
            for (int i = 0; i < loadedList.list.Count; i++)
            {
                data.index.Add(loadedList.list[i]);
            }
        }
        
        SceneManager.LoadScene("Scene1");
    }
}
