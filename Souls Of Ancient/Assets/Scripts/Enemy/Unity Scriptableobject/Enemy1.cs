using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    public float enemyHealth=20;



    public void TakeDamage()
    {
        enemyHealth -=10;
        if(enemyHealth<10)
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        
    }


    void Update()
    {
        TakeDamage();
    }
}
