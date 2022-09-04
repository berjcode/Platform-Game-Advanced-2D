using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunC : MonoBehaviour
{
    public static GunC Instance {get; set;}
    public void Awake()
    {
        Instance = this;
    }
   
   //private Vector3 mousePos;
    public Transform rightBulletSpawner;
   
    public GameObject leftBullets,rightBullets;
    public bool isLookingLeft;

    
    void Update()
    {
       
        
        FireSystem();
    }

 public void Shoot()
    {   if(isLookingLeft)
    {
        Instantiate(rightBullets,transform.position,Quaternion.identity);
    }else 
    {
        Instantiate(leftBullets,transform.position,Quaternion.identity);
    }
    }
    public void FireSystem()
        {
        if(Input.GetMouseButtonDown(0))
        {
            
            Shoot();
        }
        }
   
        

    

    
}
