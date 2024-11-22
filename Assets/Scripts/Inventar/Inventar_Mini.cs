using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.FilePathAttribute;
using UnityEngine.UI;

public class Inventar_Mini : MonoBehaviour
{
    public XmlDocument xml;
    private string localPath;
    private void Start()
    {
        Create_XML();
    }
    private void Create_XML()
    {
        localPath = Application.streamingAssetsPath + "/" + gameObject.name + ".XML";
        if (!File.Exists(localPath))
        {
            xml = new XmlDocument();
            XmlDeclaration xmldecl = xml.CreateXmlDeclaration("1.0", "UTF-8", "");
            XmlElement root = xml.CreateElement("Data");
            xml.AppendChild(root);
            xml.Save(localPath);
        }
    }

    public void AddXML(int tool)
    {
        localPath = Application.streamingAssetsPath + "/" + gameObject.name + ".XML";
        if (File.Exists(localPath))
        {
            xml = new XmlDocument();
            xml.Load(localPath);
            XmlNode root = xml.SelectSingleNode("Data");
            XmlElement info = xml.CreateElement("Info");
            info.SetAttribute("IndexTool", "" + tool);
            root.AppendChild(info);
            xml.AppendChild(root);
            xml.Save(localPath);
            Debug.Log("Add XML success!");
        }
    }
    public void Readxml()
    {
        localPath = Application.streamingAssetsPath + "/" + gameObject.name + ".XML";
        if (File.Exists(localPath))
        {
            xml = new XmlDocument();
            xml.Load(localPath);
            XmlNodeList nodeList = xml.SelectSingleNode("Data").ChildNodes;
            foreach (XmlElement xe in nodeList)
            {
                if (xe.Name == "Info")
                {
                    if (xe.Name == "Info")
                    {
                        for (int i = 0; i < xe.Attributes.Count; i++)
                        {
                            int p = int.Parse(xe.GetAttribute("IndexTool"));
                            Inv_Pers.rid.InvOn();
                            Inv_Pers.rid.index.Add(p);
                        }
                    }
                    //text.text = (xe.GetAttribute("Name")) + " " + (xe.GetAttribute("Famely")) + " Возраст:" + (xe.GetAttribute("Age")) + " телефон:" + (xe.GetAttribute("Phone"));
                    // Debug.Log(xe.GetAttribute("Name"));
                    // Debug.Log(xe.GetAttribute("Age"));
                    //Debug.Log(xe.GetAttribute("Phone"));
                }
            }
        }
    }
}

