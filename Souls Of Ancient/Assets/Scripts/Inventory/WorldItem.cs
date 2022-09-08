using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldItem : MonoBehaviour
{
    public Item _item;
    public int amount;
   
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        this.GetComponent<SpriteRenderer>().sprite = _item.Icon;
        
    }
}
