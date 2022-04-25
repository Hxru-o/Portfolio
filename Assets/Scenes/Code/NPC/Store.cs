using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    
    public Transform slotRoot;
    public ItemBuffer itemBuffer;
    PlayerController enterPlayer;
    public RectTransform storeui;
    private List<StoreSlot> slots;

    public System.Action<ItemProperty> onSlotClick;

    void Start()
    {
        slots = new List<StoreSlot>();
        int SlotCount = slotRoot.childCount;
        

        for (int i = 0; i< SlotCount; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<StoreSlot>();

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

    void Update()
    {
        
    }

    public void Enter(PlayerController player)
    {
        enterPlayer = player;
        storeui.anchoredPosition = Vector3.zero;

    }

    void Exit()
    { 
    storeui.anchoredPosition = Vector3.down * 1000;

    }
    public void OnclickSlot(StoreSlot slot)
    {
         if(onSlotClick != null)
         {
             onSlotClick(slot.item);
         }
    }
}
