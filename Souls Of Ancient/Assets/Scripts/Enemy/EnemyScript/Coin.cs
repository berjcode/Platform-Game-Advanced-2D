using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    

    void OnTriggerEnter2D(Collider2D col)
    
    {
         if(col.gameObject.tag=="Player")
            {
                ScoreManager.Instance.playerCoinMagic += Random.Range(0,15);
                ScoreManager.Instance.coinMagicText.text = ScoreManager.Instance.playerCoinMagic.ToString();
             
                Destroy(gameObject);
            }
    }


}
