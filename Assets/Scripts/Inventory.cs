using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    GameObject inventoryUI;
    bool inventoryUIState;
    static int limitList;

    static List<Item> inventory;
    public static int s_myID;
    public InventoryItemContainer[] inventoryItemContainers;
    public static InventoryItemContainer[] s_inventoryItemContainers;
    // Start is called before the first frame update
    void Start()
    {
        inventory = new List<Item>();
        s_inventoryItemContainers = inventoryItemContainers;
        limitList = inventoryItemContainers.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUIState = !inventoryUIState;
            inventoryUI.GetComponent<CanvasGroup>().alpha = Convert.ToInt32(inventoryUIState);
        }
    }
    public static void DiscardItem(Item item)
    {
        for(int i = 0; i < inventory.Count; i++)
        {
            if(inventory[i] == item)
            {
                inventory.RemoveAt(i);
                for(int j = 0; j < s_inventoryItemContainers.Length; j++)
                {
                    if(s_inventoryItemContainers[j].GetImage().sprite == item.GetSpriteItem())
                    {
                        s_inventoryItemContainers[j].GetImage().enabled = false;
                    }
                }
            }
        }
    }
    public static void SaveItem(Item item)
    {
        if(inventory.Count >= limitList)
        {
            return;
        }

        inventory.Add(item); 

        for(int i= 0; i< s_inventoryItemContainers.Length; i++)
        {
            if(s_inventoryItemContainers[i].GetImage().enabled == false)
            {
                s_inventoryItemContainers[i].SetItemImage(item.GetSpriteItem());
                Debug.Log("Has recolectado un item");
                Debug.Log(inventory.Count);
                return;
            }
        }
        
        Debug.Log("Has recolectado un item");
        Debug.Log(inventory.Count);
    }
    
    public static bool HasKey(string index)
    {
        foreach(var item in inventory)
        {
            Key key = item as Key;

            if (key)
            {
                if (key.GetId() == index)
                {
                    DiscardItem(item);
                    return true;
                }
            }           
                
        }

        return false;
    }

}
