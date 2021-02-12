using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
	[Header("Values")]
    [SerializeField] string[] text;

	async void Start()
    {
        await Task.Delay(100);
        switch(Settings.language)
        {
            case "EN":
                GetComponent<Text>().text = text[0];
                break;
            case "RU":
                GetComponent<Text>().text = text[1];
                break;
            default:
                Debug.LogError("Language not selected");
                GetComponent<Text>().text = "Language not selected";
                break;
        }
    }
}
