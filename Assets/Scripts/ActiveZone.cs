﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveZone : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject selectedNow;
    [SerializeField] GameObject selectedDefault;

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Lever":
                selectedNow = col.gameObject;
                Alpha.On(selectedNow.GetComponent<Lever>().selected, 1);
                break;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject == selectedNow)
            switch (selectedNow.tag)
            {
                case "Lever":
                    Alpha.Off(selectedNow.GetComponent<Lever>().selected, 1);
                    selectedNow = selectedDefault;
                    break;
            }
    }

    //Почему бы и не здесь...
    void Update()
    {
        if (Input.GetKeyDown(Settings.active))
        {
            switch (selectedNow.tag)
            {
                case "Lever":
                    selectedNow.GetComponent<Lever>().Active();
                    break;
            }
        }
    }
}
