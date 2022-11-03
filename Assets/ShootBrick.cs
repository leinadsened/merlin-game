using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBrick : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject prefabToSpawn;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            SpawnBrick();
        }
    }
    void SpawnBrick(){
        Instantiate(prefabToSpawn, spawnPoint.transform.position, transform.rotation);
    }
}
