using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject portal;
    private GameObject player;
    void Start()
    {
        player =GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag =="Player")
        {
            player.transform.position= new Vector2(portal.transform.position.x, portal.transform.position.y);
        }
        }
       


}
