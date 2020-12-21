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
        //objectToBeActived.GetComponent<Active>().Active(isActive);
    }

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
}
