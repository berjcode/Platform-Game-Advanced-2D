using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Food Item",menuName ="Inventory And Item/Food")]
public class Food : Item
{
    public ItemType itemType = ItemType.Food;

    public float doygunluk;

    public override void UseEffect()
    {
        Debug.Log("Yemek yedim.");
    }
   
}
