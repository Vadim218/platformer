using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] string sceneName;
    [SerializeField] Transform loadScreen;
    [SerializeField] bool activeByTrigger;
	GameObject blackScreen;
    GameObject progressBG;
    GameObject progressBar;
    GameObject progressText;
    AsyncOperation operation;
    float progress;

    void OnOff(bool on)
    {
        if(on)
        {
            Alpha.On(blackScreen, 1, true, true);
            Alpha.On(progressBG, 1, true, true);
            Alpha.On(progressBar, 1, true, true);
            Alpha.On(progressText, 1, true, true);
        }
        else
        {
            Alpha.Off(blackScreen, 1, true, false);
            Alpha.Off(progressBG, 1, true, false);
            Alpha.Off(progressBar, 1, true, false);
            Alpha.Off(progressText, 1, true, false);
        }
    }

    void Progress()
    {
        if(operation != null)
            progress = operation.progress / 0.9f;
        progressBar.GetComponent<Image>().fillAmount = progress;
        progressText.GetComponent<Text>().text = string.Format("{0:0}%", progress * 100);
    }

    public async void Load()
    {
        Progress();
        OnOff(true);

        while(blackScreen.GetComponent<Image>().color.a != 1)
            await Task.Delay(1);

        operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        while (progress != 1)
        {
            Progress();
            await Task.Delay(1);
        }

        Progress();
        operation.allowSceneActivation = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player" && activeByTrigger)
        {
            Load();
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void Start()
    {
        blackScreen = loadScreen.gameObject;
        progressBG = loadScreen.GetChild(0).gameObject;
        progressBar = loadScreen.GetChild(1).gameObject;
        progressText = loadScreen.GetChild(2).gameObject;
        OnOff(false);
    }
}