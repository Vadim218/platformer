using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StoneTurretArrow : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 force;
    Vector3 rotation;

    public void Shoot(StoneTurret.Rotation lookAt){
        switch(lookAt){
            case StoneTurret.Rotation.Up:
                force = new Vector2(0, 750);
                rotation = new Vector3(0, 0, -90);
                break;
            case StoneTurret.Rotation.Down:
                force = new Vector2(0, -750);
                rotation = new Vector3(0, 0, 90);
                break;
            case StoneTurret.Rotation.Right:
                force = new Vector2(750, 0);
                rotation = new Vector3(0, 0, 180);
                break;
            case StoneTurret.Rotation.Left:
                force = new Vector2(-750, 0);
                rotation = new Vector3(0, 0, 0);
                break;
        }

        transform.position = GetComponentInParent<Transform>().position;
        transform.rotation = Quaternion.Euler(rotation);

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(force);
    }

    async void OnTriggerEnter2D(Collider2D col){
        if(!col.gameObject.GetComponent<StoneTurret>() && !col.gameObject.GetComponent<ActiveZone>()){
            GetComponent<Collider2D>().enabled = false;
            Alpha.Off(gameObject, 1, true);
            await Task.Delay(25);
            rb = GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}