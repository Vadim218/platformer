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
    float shift = -0.088f;

    void Shoot(){
        if(isActive){
            GameObject arr = Instantiate(arrow, transform);
            switch (lookAt){
                case Rotation.Up:
                    arr.GetComponent<StoneTurretArrow>().Shoot(-90, shift);
                    break;
                case Rotation.Down:
                    arr.GetComponent<StoneTurretArrow>().Shoot(90, shift);
                    break;
                case Rotation.Right:
                    arr.GetComponent<StoneTurretArrow>().Shoot(180, shift);
                    break;
                case Rotation.Left:
                    arr.GetComponent<StoneTurretArrow>().Shoot(0, shift);
                    break;
            }
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
