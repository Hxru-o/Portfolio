using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
   public DropItem item;
   public int itemCount;
   public Image itemImage;


//Component
   [SerializeField]
   private Text text_Count;
   [SerializeField]
   private GameObject countImage;

   private void SetColor(float _alpha)
   {
       Color color = itemImage.color;
       color.a = _alpha;
       itemImage.color = color;
   }
   public void AddItem(DropItem _item, int _count = 1)
   {
       item = _item;
       itemCount = _count;
       itemImage.sprite = item.itemImage;
       
       countImage.SetActive(true);
       text_Count.text = itemCount.ToString();

       SetColor(1);
   }

   private void clearSlot()
   {
       item = null;
       itemCount = 0;
       itemImage.sprite = null;

       text_Count.text = "0";
       countImage.SetActive(false);
   }

   public void SetSlotCount(int _count)
   {
       itemCount += _count;
       text_Count.text = itemCount.ToString();

       if(itemCount <= 0)
       {
          clearSlot();
       } 
   }
}
