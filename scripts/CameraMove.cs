using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("Objects")]
    public GameObject player;

    float x;
    float y;
    float xVel;
    float yVel;

    void Update()
    {
        x = Mathf.SmoothDamp(x, player.transform.position.x, ref xVel, 0.5f);
        y = Mathf.SmoothDamp(y, player.transform.position.y, ref yVel, 0.5f);
        transform.position = new Vector3(x, y, -10f);
    }
}