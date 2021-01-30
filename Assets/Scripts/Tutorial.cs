using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] KeyCode[] buttons;
    [Header("Objects")]
	[SerializeField] GameObject[] texts;
	[SerializeField] GameObject[] buttonImgs;

	IEnumerator Wait()
    {
        while (true)
        {
            foreach(KeyCode key in buttons)
            	if(Input.GetKeyDown(key)){
            		Stop(key);
            		StopCoroutine("Wait");
            	}
            yield return null;
        }
    }

    async void Stop(KeyCode key){
    	foreach(GameObject img in buttonImgs)
    		if(img.name == key.ToString())
    			img.GetComponent<Animator>().SetTrigger("Press");

    	await Task.Delay(1000);
    	foreach(GameObject text in texts)
    		Alpha.Off(text, 1, true);
    	foreach(GameObject img in buttonImgs)
    		Alpha.Off(img, 1, true);

        Destroy(gameObject);
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.tag == "Player"){
            StopCoroutine("Wait");
            foreach(GameObject text in texts)
                Alpha.Off(text, 1);
            foreach(GameObject img in buttonImgs)
                Alpha.Off(img, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
    	if(col.tag == "Player"){
    		StartCoroutine("Wait");
    		foreach(GameObject text in texts)
    			Alpha.On(text, 1);
    		foreach(GameObject img in buttonImgs)
    			Alpha.On(img, 1);
    	}
    }
}
