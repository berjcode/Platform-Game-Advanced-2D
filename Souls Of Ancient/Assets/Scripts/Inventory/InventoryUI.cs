using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory _playerInventory;
    public GameObject[] slotObject = new GameObject[24];

    public GameObject slotPrefab;
    public GameObject _inventoryPanel;
    public Item item;

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
           obj.GetComponent<Button>().onClick.AddListener(delegate{_playerInventory.UseItem(_playerInventory.itemSlot[i]);
           });
            slotObject[i] = obj;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        WorldItem item = col.gameObject.GetComponent<WorldItem>();
        if(item != null)
        {
            _playerInventory.AddItem(item._item,item.amount);
            Destroy(item.gameObject);
        }
    }
}
