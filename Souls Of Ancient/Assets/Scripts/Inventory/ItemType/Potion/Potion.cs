using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Potion" ,menuName ="Inventory And Item/Potion")]
public class Potion : Item
{
   public ItemType itemType = ItemType.Potion;

   public int health;
   public override void UseEffect()
   {
    GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>().HealthPlayer+= health;
     ScoreManager.Instance.healthText.text = ScoreManager.Instance.HealthPlayer.ToString();
   }
   
}
