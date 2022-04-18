using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   public Transform rootSlot;
   public Store store;

   private List<StoreSlot> Storeslots;
   public GameObject inventoryPanel;
   bool activeInventory = false;

   [SerializeField]
   private GameObject SlotParent;

   private InventorySlot[] slots;

void Start()
{
  inventoryPanel.SetActive(activeInventory);
  
  Storeslots = new List<StoreSlot>();

  slots = SlotParent.GetComponentsInChildren<InventorySlot>();

  int slotCnt = rootSlot.childCount;

  for(int i = 0; i < slotCnt; i++)
  {
      var slot = rootSlot.GetChild(i).GetComponent<StoreSlot>();

      Storeslots.Add(slot);
  }
  store.onSlotClick += BuyItem;     
}

private void Update() 
{
   if(Input.GetButtonDown("Inventory"))
   {
   activeInventory = !activeInventory;
   inventoryPanel.SetActive(activeInventory);
   }   
}

void BuyItem(ItemProperty item)
{
  var emptySlot = Storeslots.Find(t => 
  {
    return t.item == null || t.item.name == string.Empty;
  });

 if(emptySlot != null)
 {
     emptySlot.SetItem(item);
 }
}

 public void Acquireitem(DropItem _item, int _count = 1)
 {
    for (int i = 0; i < slots.Length; i++)
    {
      if(slots[i].item != null)
      {
        if(slots[i].item.itemName == _item.itemName)
        {
          slots[i].SetSlotCount(_count);
          return;
        }
      }
      
    }
     for (int i = 0; i < slots.Length; i++)
    {
      if(slots[i].item == null)
      {
        slots[i].AddItem(_item, _count);
        return;
      }
    }
 }
}
