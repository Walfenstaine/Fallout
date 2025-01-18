using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class Iventory : MonoBehaviour
{
    public DataBase date;

    public List<ItemIventory> items = new List<ItemIventory > ();

    public GameObject gameObgShow;

    public GameObject InventoryMainObject;
    public int maxCount;

    public Camera Cam;
    public EventSystem es;

    public int currentID;
    public ItemIventory currentItem;

    public RectTransform movingOBlect;
    public Vector3 offset;

    public void Start()
    {
        if (items.Count == 0)
        {
            AddGraphics();
        }

        for (int i= 0; i < maxCount; i++) //тест, заполнить рандомные €чейки
        {
            AddItem(i, Data.items[Random.Range(0,date.items.Count)],Random.Range(1, 99));
        }
        UpdateIventory();
    }

    public void Update()
    {
        if(currentID != -1)
        {
            MoveObject();
        }
    }

    public void AddItem(int id, Item item, int count)
    {
        items[id].id = invItem.id;
        items[id].count = invItem.count;
        items[id].itemGameObj.Getcomponent<Image>().sprite = Data.items[invItem.id].img;

        if(invItem.count > 1 && invItem.id != 0)
        {
            items[id].itemGameObg.GetComponentInChildren<Text>().text = invItem.count.ToString();
        }
        else
        {
            items[id].itemGameObg.GetComponentInChildren<Text>().text = "";
        }


    }

    public void AddInventoryItem(int id, ItemIventory invItem)
    {
        items[id].id = invItem.id;
        items[id].count = invItem.count;
        items[id].itemGameObj.Getcomponent<Imaige>().sprite = item.img;

        if (invItem.count > 1 && item.id != 0)
        {
            items[id].itemGameObg.GetComponentInChildren<Text>().text = invItem.count.ToString();
        }
        else
        {
            items[id].itemGameObg.GetComponentInChildren<Text>().text = "";
        }


    }


    public void AddGraphics()
    {
        for (int i = 0; i < maxCount; i++)
        {
            GameObject newItem = Instantiate(gameObgShow, IventoryMainObject.transform) as GameObject;

            newItem.name = i.ToString();

            ItemIventory ii = new ItemIventory();
            ii.itemGameObg = newItem;

            RectTransform rt = newItem.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(0, 0, 0);
            rt.localScale = new Vector3(1, 1, 1);
            newItem.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);

            Button tempButton = newItem.GetComponent<Button>();

            tempButton.onClick.AddListener(delegate { SelectObject(); });

            items.Add(ii);
        }
    }

    public void UpdateInventory()
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (items[i].id != 0 && items[i].count > 1)
            {
                items[i].itemGameObg.GetComponentInChildren<Text>().text = items[i].count.ToString();
            }
            else
            {
                items[i].itemGameObg.GetComponentInChildren<Text>().text = "";
            }

            items[i].itemGameObg.GetComponent<Image>().sprite = data.items[items[i].id].img;
        }
    }

    public void SelectObject()
    {
        if (currentID == -1) 
        {
            currentID = int.Parse(es.currentSelectedGameObject.name);
            currentItem = CopyInventoryItem(items[currentID]);
            movingOBlect.gameObject.SetActive(true);
            movingOBlect.GetComponent<Image>().sprite = date.items[currentItem.id].image;

            AddItem(currentID, data.items[0], 0);
        }
        else
        {
            AddInventoryItem(currentID, items[int.Parse(es.currentSelectedGameObject.name)]);

            AddInventoryItem(int.Parse(es.currentSelectedGameObject.name), currentItem);
            currentID = -1;

            movingOBlect.gameObject.SetActive(false);
        }
    }


    public void MoveObject()
    {
        Vector3 pos = Input.mousePosition + offset;
        pos.z = InventoryMainObject.GetComponent<RectTransform>().position.z;
        movingOBlect.position = Cam.ScreenToWorldPoint(pos);
    }

    public ItemIventory CopyInventoryItem(ItemIventory old)
    {
        ItemIventory New = new ItemIventory();

        New.id = old.id;
        New.itemGameObl = old.iitemGameObj;
        New.count = old.count;

        return New;
    }
}

[Sustem.Serializable]

public class ItemIventory
{
    public int id;
    public GameObject itemGameObg;

    public int count;
}