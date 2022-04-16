using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    
    public Transform slotRoot;
    public ItemBuffer itemBuffer;
    private List<Slot> slots;

    public System.Action<ItemProperty> onSlotClick;

    void Start()
    {
        slots = new List<Slot>();
        int SlotCount = slotRoot.childCount;
        

        for (int i = 0; i< SlotCount; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();

            if(i < itemBuffer.items.Count)
            {
                slot.SetItem(itemBuffer.items[i]);
            }

            else
            { 
              slot.GetComponent<UnityEngine.UI.Button>().interactable = false;

            }
            
            slots.Add(slot);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnclickSlot(Slot slot)
    {
         if(onSlotClick != null)
         {
             onSlotClick(slot.item);
         }
    }
}
