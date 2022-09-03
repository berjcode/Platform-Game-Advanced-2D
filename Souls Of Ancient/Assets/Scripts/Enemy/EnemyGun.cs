using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] GameObject enemyBullet;
    float fireRate;
    float nextFire;

    void Start()
    {
        fireRate=1f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {   
        CheckIfTimeToFire();        
    }

    void  CheckIfTimeToFire()
    {
        if(Time.time > nextFire)
        {
            Instantiate(enemyBullet,transform.position,Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
