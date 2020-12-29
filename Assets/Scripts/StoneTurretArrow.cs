using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StoneTurretArrow : MonoBehaviour
{
    Rigidbody2D rb;

    public void Shoot(float rotation, float shift){
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
        transform.Translate(shift, 0, 0);

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.TransformDirection(new Vector3(-750, 0)));

        transform.SetParent(Arrows.arrowsTransform);
    }

    async void OnTriggerEnter2D(Collider2D col){
        if (!col.GetComponent<StoneTurret>() &&
            !col.GetComponent<StoneAutoTurret>() &&
            !col.GetComponent<ActiveZone>() &&
            !col.GetComponent<StonePlatformTrigger>()){
            GetComponent<Collider2D>().enabled = false;
            Alpha.Off(gameObject, 1, true);
            await Task.Delay(25);

            rb = GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}