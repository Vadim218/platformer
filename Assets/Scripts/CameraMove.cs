using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject player;
    float xSpeed = 0.42f;
    float ySpeed = 0.42f;

    float x;
    float y;
    float xVel;
    float yVel;

    IEnumerator Respawn()
    {
        while (true)
        {
            if(PlusMinus(x, player.transform.position.x) && PlusMinus(y, player.transform.position.y))
            {
                xSpeed *= 2;
                ySpeed *= 2;
                break;
            }
            yield return null;
        }
    }

    public void Dead()
    {
        xSpeed /= 2;
        ySpeed /= 2;
        StartCoroutine("Respawn");
    }

    bool PlusMinus(float x, float value)
    {
        if (value - 1 < x && x < value + 1)
            return true;
        return false;
    }

    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
    }

    void Update()
    {
        x = Mathf.SmoothDamp(x, player.transform.position.x, ref xVel, 0.5f);
        y = Mathf.SmoothDamp(y, player.transform.position.y, ref yVel, 0.5f);
        transform.position = new Vector3(x, y, -10f);
    }
}