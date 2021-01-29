using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Message : MonoBehaviour
{
    [Header("Values")]
	[SerializeField] string[] message;
	[SerializeField] int delay;
	[SerializeField] int destroyDelay;
	[SerializeField] bool activeOnStart;
	[SerializeField] [Min(1)] int startDelay;

    string SelectedLang()
    {
        switch(Settings.language)
        {
            case "EN":
                return message[0];
                break;
            case "RU":
                return message[1];
                break;
            default:
                Debug.LogError("Language not selected");
                return "Language not selected";
                break;
        }
    }

    public async void Active()
    {
    	foreach(char c in SelectedLang())
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
