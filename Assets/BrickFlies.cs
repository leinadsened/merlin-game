using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickFlies : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public int maxCollisions = 1;
    int collisions = 0;
    void Start(){
    //give it the direction you want as before;
    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    rb = GetComponent<Rigidbody2D>();
    rb.velocity = (mousePosition + new Vector2 (9, 0));
    print(rb.velocity);
}

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
        {
        
        if (collision.gameObject.name.Contains("Black")){
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name.Contains("BTN")){
            collisions++;
            if (collisions > maxCollisions){
                Destroy(this.gameObject);
            }
        }

        }
}
