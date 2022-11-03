using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionDestroyed : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject prefabToSpawn;
    // Start is called before the first frame update
    
    private UIManager uiManager;
    void Start(){
        uiManager = GameObject.Find("Text (TMP)").GetComponent<UIManager>();
        if (uiManager == null){
            Debug.LogError("The UI Manager is Null");
        }
    }
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (uiManager == null){
            Debug.LogError("The UI Manager is Null");
        }
        else{
            uiManager.UpdateScore();
            uiManager.UpdateScore();
            uiManager.UpdateScore();
            Vector3 spawnPoint = spawnPoints[Random.Range(0,spawnPoints.Length)].transform.position;
            Instantiate(prefabToSpawn, spawnPoint, transform.rotation);
            Destroy(this.gameObject);
        }
        
        }
    
}

