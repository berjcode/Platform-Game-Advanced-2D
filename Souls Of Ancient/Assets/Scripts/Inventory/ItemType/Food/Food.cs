using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Food Item",menuName ="Inventory And Item/Food")]
public class Food : Item
{
    public ItemType itemType = ItemType.Food;

    public float  saturation;

    public override void UseEffect()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>().HungerPlayer+= saturation;
         ScoreManager.Instance.hungerText.text = ScoreManager.Instance.HungerPlayer.ToString();
       
    }
   
}
