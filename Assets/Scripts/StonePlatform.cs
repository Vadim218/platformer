using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonePlatform : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] bool isActive;
    [SerializeField] bool isLoop;
    [SerializeField] bool onStart;
    [SerializeField] float speed = .5f;
    [Header("Objects")]
    [SerializeField] GameObject platform;
    float lenght;

    public void Active(bool active)
    {
        isActive = active;
    }

    void Start()
    {
        lenght = GetComponentInChildren<RepeatedObject>().Count + 1;
    }

    void Update()
    {
        if (isActive)
        {
            if (onStart)
                platform.transform.Translate(speed * Time.deltaTime, 0, 0);
            else
                platform.transform.Translate(-speed * Time.deltaTime, 0, 0);

            if (platform.transform.localPosition.x > lenght)
            {
                onStart = !onStart;
                if (!isLoop)
                    isActive = !isActive;
            }
            if (platform.transform.localPosition.x < 0)
                onStart = !onStart;
        }
    }
}
