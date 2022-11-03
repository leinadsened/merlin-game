using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject prefabToSpawn;
    // Start is called before the first frame update
    
    void OnCollisionEnter2D()
    {
        for(int i = 0; i < 2; i++){
        Vector3 spawnPoint = spawnPoints[Random.Range(0,spawnPoints.Length)].transform.position;
        Instantiate(prefabToSpawn, spawnPoint, transform.rotation);
        }
    } 
    
}
