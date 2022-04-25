using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public PlayerController player;

    public Text CoinTxt;



 void LateUpdate() 
 {
    CoinTxt.text = string.Format("{0:n0}" , player.coin);
 }
}