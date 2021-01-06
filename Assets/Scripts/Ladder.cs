using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] float speed = 190;
    
    // Умножение на deltaTime не нужно поскольку движение и так просчитываеться в FixedUpdate
    void OnTriggerStay2D(Collider2D col){
        if (col.tag == "Player" && !col.GetComponent<ActiveZone>()){
            Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;

            if (Input.GetKey(Settings.up))
                rb.velocity = new Vector2(0, speed * Time.deltaTime);
            else
                if (Input.GetKey(Settings.down))
                    rb.velocity = new Vector2(0, -speed * Time.deltaTime);
                else
                    rb.velocity = Vector2.zero;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if (col.tag == "Player" && !col.GetComponent<ActiveZone>())
            col.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
