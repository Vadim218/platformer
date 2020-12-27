using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class StoneTurret : MonoBehaviour
{
	[Header("Values")]
	[SerializeField] bool isActive;
	[SerializeField] bool isLoop;
    [SerializeField] [Min(1)] int delay = 1;
	public enum Rotation {Up, Down, Right, Left};
	[SerializeField] Rotation lookAt;
    [Header("Objects")]
    [SerializeField] GameObject arrow;

    void Shoot(){
        GameObject arr = Instantiate(arrow, transform);
        arr.GetComponent<StoneTurretArrow>().Shoot(lookAt);
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

    void Start()
    {
        switch (lookAt){
            case Rotation.Up:
                transform.rotation = Quaternion.Euler(0, 0, -90);
                break;
            case Rotation.Down:
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case Rotation.Right:
                GetComponent<SpriteRenderer>().flipX = true;
                break;
        }
    }
}
