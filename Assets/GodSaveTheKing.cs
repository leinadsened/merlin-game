using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodSaveTheKing : MonoBehaviour
{
    private UIManager uiManager;
    private bool alive;
    void Start(){
        uiManager = GameObject.Find("Text (TMP)").GetComponent<UIManager>();
        if (uiManager == null){
            Debug.LogError("The UI Manager is Null");
        }
        alive = true;
    }

    public int moveSpeed = 8;
    private GameObject player;
    void Update()
    {   
        player = GameObject.Find("Player");
        if (player != null && alive){

            Vector2 kingPosition = player.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, kingPosition, moveSpeed * Time.deltaTime);   
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && alive)
        {
            Destroy(this.gameObject);
            uiManager.DamageKing();
            print(this.gameObject.name + " attacked the king!");
            alive = false;
        }
    }
}
