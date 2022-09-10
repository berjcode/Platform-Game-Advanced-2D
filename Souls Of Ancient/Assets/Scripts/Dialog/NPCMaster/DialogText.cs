using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DialogText 
{
    public string context;
    public Speaker Speaker;

}

public enum Speaker
{
    Player,
    Npc
}
