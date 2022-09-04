using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    public int slotId;
    public Item item;
    public int amount;

    public InventorySlot(int _id, Item _item, int _amount)
    {
            slotId = _id;
            item= _item;
            amount =_amount;
    }

    public void AddAmount(int _amount)
    {
        amount += _amount;
    }
    public void UpdateSlot(int _id, Item _item, int _amount)
    {
         slotId = _id;
            item= _item;
            amount =_amount;
    }

}
