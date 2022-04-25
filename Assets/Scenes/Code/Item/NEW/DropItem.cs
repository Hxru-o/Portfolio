using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class DropItem : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;

    public GameObject itemPrefab;  //아이템의 실체 -> 프리팹을 드랍

    public string ToolType;

    public enum ItemType
    {
        Apple,
        Rock,
        Fish
    }
   
}
