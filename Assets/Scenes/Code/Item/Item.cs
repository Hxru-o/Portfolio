using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipment,
    Consumables,
    ETC

}



[System.Serializable]
public class Item 
{
    public ItemType itemType;
    public string itemName;
    public Sprite ItemImage;

    public bool Use()
    {
       return false;
    }

}
