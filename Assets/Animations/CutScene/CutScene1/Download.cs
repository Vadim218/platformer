using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Download : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
    	SceneManager.LoadScene("LVL1");
    }
}
