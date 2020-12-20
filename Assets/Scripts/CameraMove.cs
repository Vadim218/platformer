using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("Objects")]
    public GameObject player;
    [Header("Values")]
    public float xSpeed = 0.42f;
    public float ySpeed = 0.42f;

    float x;
    float y;
    float xVel;
    float yVel;
    
    void Update()
    {
        x = Mathf.SmoothDamp(x, player.transform.position.x, ref xVel, xSpeed);
        y = Mathf.SmoothDamp(y, player.transform.position.y, ref yVel, ySpeed);
        transform.position = new Vector3(x, y, -10f); 
    }
}
