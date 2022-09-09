using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class MissionOneMoney : MonoBehaviour
{
    
    public UnityEvent coinDiscovery;


    void Start()
    {
        if(coinDiscovery ==null)
        {
            coinDiscovery = new UnityEvent();

        }
    }
    void OnTriggerEnter2D(Collider2D col)
    
    {
         if(col.gameObject.tag=="Player")
            {
                coinDiscovery.Invoke();
                ScoreManager.Instance.playerCoinMagic += 100;
                ScoreManager.Instance.coinMagicText.text = ScoreManager.Instance.playerCoinMagic.ToString();
             
                Destroy(gameObject);
            }
    }
    

}
