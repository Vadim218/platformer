﻿using System.Collections;
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
    [SerializeField] List<GameObject> toMove;
    float lenght;

    public void AddToMove(GameObject obj){
        toMove.Add(obj);
    }

    public void RemoveToMove(GameObject obj){
        toMove.Remove(obj);
    }

    public void Active(bool active)
    {
        isActive = active;
    }

    void Start()
    {
        lenght = GetComponentInChildren<RepeatedObject>().Count + 1;
        toMove.Add(platform);
    }

    void Update()
    {
        if (isActive)
        {
            if (onStart)
                for(int i = 0; i < toMove.ToArray().Length; i++)
                    toMove[i].transform.Translate(speed * Time.deltaTime, 0, 0);
            else
                for(int i = 0; i < toMove.ToArray().Length; i++)
                    toMove[i].transform.Translate(-speed * Time.deltaTime, 0, 0);

            if (platform.transform.localPosition.x > lenght){
                onStart = !onStart;
                if (!isLoop)
                    isActive = !isActive;
            }
            if (platform.transform.localPosition.x < 0)
                onStart = !onStart;
        }
    }
}
