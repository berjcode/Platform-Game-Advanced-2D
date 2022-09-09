using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public int ID;
    public Sprite Icon;
    public string Name;
    public bool stackable;
    public int cost;

    public virtual void UseEffect()
    {

    }

}
public enum ItemType
{
    Food,
    Potion,
    Weapon,
    Armor
}
