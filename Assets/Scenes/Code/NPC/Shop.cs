using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public RectTransform uiGroup;
    public int[] itemPrice;
    public GameObject[] itemObj;
    public Transform[] itemPos;

    PlayerController enterPlayer;
   
    public string[] talkData;
    public Text talkText;

    
    

    public void Enter(PlayerController player)
    {
        enterPlayer = player;
        uiGroup.anchoredPosition = Vector3.zero;
    }

 
    public void Exit()
    {
        uiGroup.anchoredPosition = Vector3.down * 1000;
    }

    public void Buy(int index)
  {
    int price = itemPrice[index];
    if(price > enterPlayer.coin)
    {
      StopCoroutine(Talk());
      StartCoroutine(Talk());
      return;
    }
    enterPlayer.coin -= price;
    
    Instantiate(itemObj[index], itemPos[index].position, itemPos[index].rotation);
  }

  IEnumerator Talk()
  {
    talkText.text = talkData[1];
    yield return new WaitForSeconds(2f);
    talkText.text = talkData[0];
  }
}
        

