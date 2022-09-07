using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float interval;
    void Start()
    {
        InvokeRepeating("SpawnStart",0.05f,interval);
    }

    private void SpawnStart()
    {
        int randPos = Random.Range(0, spawnPoints.Length);
        GameObject newEnemy = Instantiate(enemyPrefab,spawnPoints[randPos].position,Quaternion.identity);
    }
    
}
