using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
public GameObject coinPrefab;
public float moveSpeed = 1;
public CapsuleCollider2D player;
void Start(){
     player = GetComponent("CapsuleCollider2D") as CapsuleCollider2D;
}
void Update()
{
    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
}
public Vector3 scaleUP = new Vector3(0.2f, 0.2f, 0.2f);
void OnCollisionEnter2D(Collision2D collision){
    if (collision.gameObject.name.Contains("Potion")){
        if (moveSpeed < 40){
            moveSpeed += 2;
        }
    }
    if (collision.gameObject.name.Contains("coin")){
        if (moveSpeed < 20){
            moveSpeed += 2;
        }
    }
    if (collision.gameObject.name.Contains("Ghost")) {
        if (moveSpeed > 1) {
            moveSpeed -= 4;
        }
    }
}
}