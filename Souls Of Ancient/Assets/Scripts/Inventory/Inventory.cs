using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventory", menuName ="Inventory And Item/Inventory")]
public class Inventory : ScriptableObject
{
    public InventorySlot[] itemSlot = new InventorySlot[24];

    public void AddItem(Item _item, int _amount)
    {
        for(int i=0;i<itemSlot.Length;i++)
        {
            if(itemSlot[i].slotId == _item.ID &&_item.stackable)
            {
                itemSlot[i].AddAmount(_amount);
                return;
            }
        }
        for(int i =0; i<itemSlot.Length;i++)
        {
            if(itemSlot[i].slotId ==0)
            {
                itemSlot[i].UpdateSlot(_item.ID,_item,_amount);
                return;
            }
        }
    }

    public void UseItem(int index)
    {
        if(itemSlot[index].slotId !=0)
        {
             itemSlot[index].item.UseEffect();
            if(itemSlot[index].amount ==1)
            {
                
                 itemSlot[index].UpdateSlot(0,null,0);
            }else if(itemSlot[index].amount >1 )
            {
                itemSlot[index].DecreaseAmount(1);
            }
           
        }
        
    }
}
