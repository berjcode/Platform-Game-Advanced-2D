using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Shop : MonoBehaviour
{
    public Inventory shopInventory;
    public int shop_coins;
    public GameObject[] slotObject = new GameObject[24];
    public GameObject slotPrefab;
    public GameObject _inventoryPanel;

    public int currentItemIndex;
    public Item currentItem;
    public GameObject Player;
    public GameObject ShopUI;
  
    public Text ItemName;
    public Image ItemIcon;
    public Text coinText;
    public Text coinMagicText;

     


    void Start()
    {
         Player = GameObject.FindGameObjectWithTag("Player");
        CreateDisplay();
        ShopUI.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
       coinText.text = shop_coins + "$";
       coinMagicText.text = ScoreManager.Instance.playerCoinMagic + "$";
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        for(int i =0; i< shopInventory.itemSlot.Length;i++)
        {
            if(shopInventory.itemSlot[i].slotId != 0)
            {
                slotObject[i].GetComponent<Image>().sprite =shopInventory.itemSlot[i].item.Icon;
                slotObject[i].GetComponentInChildren<Text>().text =shopInventory.itemSlot[i].amount.ToString();
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
        for(int i =0; i < shopInventory.itemSlot.Length;i++)
        {
            GameObject obj= Instantiate(slotPrefab,_inventoryPanel.transform,false);

           if(shopInventory.itemSlot[i].slotId!=0)
           {
             
            obj.GetComponent<Image>().sprite = shopInventory.itemSlot[i].item.Icon;

           }
           slotObject[i] = obj;
           obj.GetComponent<Button>().onClick.AddListener(delegate{SelectItem(Array.IndexOf(slotObject,obj));
           });

            
        }
    }

    public void SelectItem(int index)
    {
         currentItemIndex = index;
        currentItem= shopInventory.itemSlot[index].item;

        ItemName.text = currentItem.Name;
        ItemIcon.sprite = currentItem.Icon;
    }

    public void Buy()
    {
        if(currentItem !=null)
        {
               
          if(currentItem.cost <=ScoreManager.Instance.playerCoinMagic)
          {
             ScoreManager.Instance.playerCoinMagic-= currentItem.cost ;  
            shop_coins += currentItem.cost;
            Player.GetComponent<InventoryUI>()._playerInventory.AddItem(currentItem,1);
            
            if( shopInventory.itemSlot[currentItemIndex].amount ==1)
            {
                
                 shopInventory.itemSlot[currentItemIndex].UpdateSlot(0,null,0);
                 currentItem =null;
            }else if( shopInventory.itemSlot[currentItemIndex].amount >1 )
            {
                shopInventory.itemSlot[currentItemIndex].DecreaseAmount(1);
            }
           
            }
           
        }
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.LeftShift))
        {
            ShopUI.SetActive(!ShopUI.activeSelf);
            
        } 
    }

    public void Sell()
    {
        if(Player.GetComponent<InventoryUI>().currentItem !=null)
        {
             if(Player.GetComponent<InventoryUI>().currentItem.cost <=shop_coins)
          {
            shopInventory.AddItem(Player.GetComponent<InventoryUI>().currentItem,1);
              shop_coins -= Player.GetComponent<InventoryUI>().currentItem.cost;
             ScoreManager.Instance.playerCoinMagic  += Player.GetComponent<InventoryUI>().currentItem.cost; 
           
            
            if(Player.GetComponent<InventoryUI>()._playerInventory.itemSlot[Player.GetComponent<InventoryUI>().currentItemIndex].amount ==1)
            {
                
                Player.GetComponent<InventoryUI>()._playerInventory.itemSlot[Player.GetComponent<InventoryUI>().currentItemIndex].UpdateSlot(0,null,0);
                Player.GetComponent<InventoryUI>().currentItem = null;
            }else if( Player.GetComponent<InventoryUI>()._playerInventory.itemSlot[Player.GetComponent<InventoryUI>().currentItemIndex].amount >1 )
            {
                Player.GetComponent<InventoryUI>()._playerInventory.itemSlot[Player.GetComponent<InventoryUI>().currentItemIndex].DecreaseAmount(1);
            }
           
            }
            
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        ShopUI.SetActive(false);
        
    }
          
}
