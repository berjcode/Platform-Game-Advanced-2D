using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject InventoryPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InventoryPanelOn();
    }

    public void InventoryPanelOn()
    {
         if(Input.GetKey(KeyCode.Tab))
         {
            InventoryPanel.SetActive(true);
         }else
          {
            InventoryPanel.SetActive(false);
          }
    }
}
