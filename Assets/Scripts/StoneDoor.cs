using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDoor : MonoBehaviour
{
    [Header("Values")]
    public bool isActive;
    Animator[] anim;

    public void Active(bool active)
    {
        isActive = active;
        if (isActive)
        {
            anim[0].SetTrigger("Open");
            anim[1].SetTrigger("Open");
        }
        else
        {
            anim[0].SetTrigger("Close");
            anim[1].SetTrigger("Close");
        }
    }

    void Start()
    {
        anim = GetComponentsInChildren<Animator>();
    }
}
