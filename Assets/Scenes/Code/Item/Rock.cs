using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rock : MonoBehaviour
{
 [SerializeField]
  private Text interactionText;
  GameObject nearObject;
  
  
  
   void OnTriggerstay(Collider other) 
        {
          if (other.tag == "DropItem")
          nearObject = other.gameObject;
        }
   void OnTriggerExit(Collider other)
   {
       if(other.tag == "DropItem")
       nearObject = null;
   }
    void AppearText()
    {
         if(nearObject.tag == "DropItem")
           {
            interactionText.gameObject.SetActive(true);
           }
          else
          {interactionText.gameObject.SetActive(false);}
    }
}
