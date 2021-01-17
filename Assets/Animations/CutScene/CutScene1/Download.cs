using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Download : MonoBehaviour
{
	public GameObject BlackScreen;

    async void OnTriggerEnter2D(Collider2D col)
    {
    	AsyncOperation Operation = SceneManager.LoadSceneAsync("LVL1");
        Operation.allowSceneActivation = false;

        Alpha.On(BlackScreen, 1);
        while(BlackScreen.GetComponent<Image>().color.a != 1)
        	await Task.Delay(1);
        await Task.Delay(250);

        Operation.allowSceneActivation = true;
    }

    void Start()
    {
        Cursor.visible = false;
    }
}
