using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private Transform playerPos;

    private int health=5;
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,playerPos.position,speed*Time.deltaTime);
        Killer();
    }


    private void OnTriggerEnter2D(Collider2D col)

    {
        if(col.tag =="Bullet")
        {
            health--;
        }

         if(col.tag =="Player")
        {
            Destroy(gameObject);
            Debug.Log("Dokundu");
        }
    }


    public void Killer()
    {
        if(health ==0)
        {
            Destroy(gameObject);

        }
    }

    

    
}
