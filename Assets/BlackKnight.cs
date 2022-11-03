using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackKnight : MonoBehaviour
{
    private UIManager uiManager;
    public int moveSpeed;
    public AudioClip clip;
    public AudioSource source;

    void Start(){
        uiManager = GameObject.Find("Text (TMP)").GetComponent<UIManager>();
        if (uiManager == null){
            Debug.LogError("The UI Manager is Null");
        }
    }
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        
       if (collision.gameObject.name.Contains("brick")){
        source.PlayOneShot(clip);
        Destroy(this.gameObject);

        if (uiManager == null){
            Debug.LogError("The UI Manager is Null");
        }
        else{
            uiManager.UpdateScore();
        }
        }
        if (collision.gameObject.name.Contains("Tower")){
            Destroy(this.gameObject);

        if (uiManager == null){
            Debug.LogError("The UI Manager is Null");
        }
        else{
            uiManager.DamageKing();
        }
        }
    }
    void Update(){
        Vector2 towerPosition = GameObject.Find("Tower").GetComponent<Transform>().position;
        moveSpeed = 2;
        transform.position = Vector2.MoveTowards(transform.position, towerPosition, moveSpeed * Time.deltaTime);
    }
}
