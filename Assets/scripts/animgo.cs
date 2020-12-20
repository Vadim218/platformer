using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animgo : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("IsRunning", true);
        }
        else {
            anim.SetBool("IsRunning", false);
        }
    }
}
