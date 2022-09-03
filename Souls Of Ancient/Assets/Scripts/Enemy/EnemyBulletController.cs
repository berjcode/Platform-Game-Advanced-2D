using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
     public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(speed*Time.deltaTime,0,0));

    

        Destroy(gameObject,1f);
    }

     void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.tag =="Player")
        {
            Destroy(gameObject);
        }
    }
}
