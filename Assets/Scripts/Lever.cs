using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [Header("Values")]
    public bool isActive;
    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isActive)
                anim.SetTrigger("Disable");
            else
                anim.SetTrigger("Enable");
            isActive = !isActive;
        }
    }
}
