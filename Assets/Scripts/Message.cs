using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Message : MonoBehaviour
{
    [Header("Values")]
	[SerializeField] string message;
	[SerializeField] int delay;
	[SerializeField] int destroyDelay;
	[SerializeField] bool activeOnStart;
	[SerializeField] int startDelay;

    public async void Active()
    {
    	foreach(char c in message)
    	{
    		GetComponent<TextMesh>().text += c;
    		await Task.Delay(delay);
    	}

    	await Task.Delay(destroyDelay);
    	Alpha.Off(gameObject, 1, true);
    }

    async void Start()
    {
    	if(activeOnStart)
    	{
    		await Task.Delay(startDelay);
    		Active();
    	}
    }
}
