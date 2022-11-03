using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndGetPoint : MonoBehaviour
{
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
        
       if (collision.gameObject.name == "Player"){
        Destroy(this.gameObject);
        if (uiManager == null){
            Debug.LogError("The UI Manager is Null");
        }
        else{
            uiManager.UpdateScore();
        }
        }
    }
}

