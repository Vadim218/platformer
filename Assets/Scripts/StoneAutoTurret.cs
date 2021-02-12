using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class StoneAutoTurret : MonoBehaviour
{
	[Header("Values")]
	[SerializeField] bool isActive;
	[SerializeField] bool isLoop;
    [SerializeField] [Min(1)] int delay = 1;
    [SerializeField] float lookAt;
    [Header("Objects")]
    [SerializeField] GameObject arrow;
    float shift = -1.2f;
	float velocity;
    bool isShoot;

    IEnumerator Look(Transform aim){
    	while(true){
    		Vector3 aimDir = (aim.position - transform.position).normalized;
    		float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
    		lookAt = Mathf.SmoothDamp(lookAt, angle, ref velocity, 0.8f);
    		transform.eulerAngles = new Vector3(0, 0, lookAt);
    		yield return null;
    	}
    }

    void OnTriggerEnter2D(Collider2D col){
    	if(col.tag == "Player")
        {
    		StartCoroutine("Look", col.transform);
            isShoot = true;
        }
    }

    void OnTriggerExit2D(Collider2D col){
    	if(col.tag == "Player")
        {
    		StopCoroutine("Look");
            isShoot = false;
        }
    }

    void Shoot(){
        if(isActive && isShoot){
            GameObject arr = Instantiate(arrow, transform);
            arr.GetComponent<StoneTurretArrow>().Shoot(lookAt + 180, shift);
        }
    }

    async void ManyShoots(){
        while(true){
            if(isActive){
                Shoot();
                await Task.Delay(delay);
            }
            else
                break;
        }
    }

	public void Active(bool active){
		isActive = active;
        if(!isLoop)
            Shoot();
        else
            ManyShoots();
	}
}