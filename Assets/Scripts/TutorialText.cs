using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
	[Header("Values")]
    [SerializeField] string[] message;

	async void Start()
    {
        await Task.Delay(100);
        switch(Settings.language)
        {
            case "EN":
                GetComponent<TextMesh>().text = message[0];
                break;
            case "RU":
                GetComponent<TextMesh>().text = message[1];
                break;
            default:
                Debug.LogError("Language not selected");
                GetComponent<TextMesh>().text = "Language not selected";
                break;
        }
    }
}
