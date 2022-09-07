using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory _playerInventory;
    public GameObject[] slotObject = new GameObject[24];

    public GameObject slotPrefab;
    public GameObject _inventoryPanel;
    public Item item;
    public int currentItemIndex;
    public Item currentItem;

    void Start()
    {
        CreateDisplay();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            _playerInventory.AddItem(item,1);
        }

        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        for(int i =0; i< _playerInventory.itemSlot.Length;i++)
        {
            if(_playerInventory.itemSlot[i].slotId != 0)
            {
                slotObject[i].GetComponent<Image>().sprite =_playerInventory.itemSlot[i].item.Icon;
                slotObject[i].GetComponentInChildren<Text>().text =_playerInventory.itemSlot[i].amount.ToString();
           }
           else
           {
            slotObject[i].GetComponent<Image>().sprite = null;
            slotObject[i].GetComponentInChildren<Text>().text =" ";
           }
            
            
            
             
           
        }
    }

    public void CreateDisplay()
    {
        for(int i =0; i < _playerInventory.itemSlot.Length;i++)
        {
            GameObject obj= Instantiate(slotPrefab,_inventoryPanel.transform,false);

           if(_playerInventory.itemSlot[i].slotId!=0)
           {
             
            obj.GetComponent<Image>().sprite = _playerInventory.itemSlot[i].item.Icon;

           }
           slotObject[i] = obj;
           obj.GetComponent<Button>().onClick.AddListener(delegate{SelectItem(Array.IndexOf(slotObject,obj));
           });

            
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        WorldItem item = col.gameObject.GetComponent<WorldItem>();
        if(item != null)
        {
            _playerInventory.AddItem(item._item,item.amount);
            Destroy(item.gameObject);
        }
    }

    public void SelectItem(int index)
    {
        currentItemIndex = index;
        currentItem= _playerInventory.itemSlot[index].item;
        
    }
    public void UseItemBtn()
    {

    }
     public void DropItemBtn()
    {
        
    }
}
