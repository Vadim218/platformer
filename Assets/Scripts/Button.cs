using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [Header("Objects")]
    public GameObject objectToBeActived;
    [Header("Values")]
    [SerializeField] bool isActive;
    Animator anim;
    GameObject onButton;

    void OnTriggerEnter2D(Collider2D col){
    	if(col.GetComponent<Rigidbody2D>() && !isActive){
    		onButton = col.gameObject;
    	    Active();
    	}
    }

    void OnTriggerExit2D(Collider2D col){
    	if(col.GetComponent<Rigidbody2D>() && col.gameObject == onButton){
    		onButton = null;
    		Active();
    	}
    }

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
        if (objectToBeActived.GetComponent<StonePlatform>())
            objectToBeActived.GetComponent<StonePlatform>().Active(isActive);
        if (objectToBeActived.GetComponent<StoneTurret>())
            objectToBeActived.GetComponent<StoneTurret>().Active(isActive);
    }

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
}