using System;
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
        SceneManager.LoadScene("Menue");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Resed()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Scene1");
    }


    public void Load() 
    {
        SceneManager.LoadScene("Scene1");
    }
}
