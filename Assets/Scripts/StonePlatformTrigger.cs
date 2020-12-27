using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonePlatformTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.GetComponent<Rigidbody2D>()){
            GetComponentInParent<StonePlatform>().AddToMove(col.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D col){
        GetComponentInParent<StonePlatform>().RemoveToMove(col.gameObject);
    }
}
