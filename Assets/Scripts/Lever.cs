using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [Header("Objects")]
    public GameObject objectToBeActived;
    public GameObject selected;
    [Header("Values")]
    public bool isActive;
    Animator anim;

    public void Active()
    {
        isActive = !isActive;
        if (isActive)
            anim.SetTrigger("Enable");
        else
            anim.SetTrigger("Disable");

        //Добавлять по if на каждый активируемый скрипт: мост лестница и т.д.
        if (objectToBeActived.GetComponent<StoneDoor>())
            objectToBeActived.GetComponent<StoneDoor>().Active(isActive);
    }

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
}
