using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UI : MonoBehaviour
{
    enum Condition { playing, paused, options}
    public static bool isPaused;
    private Condition cond = Condition.playing;
    [Header("Objects")]
    [SerializeField] GameObject BG;
    [SerializeField] GameObject[] pauseImgs;
    [SerializeField] GameObject[] optionsImgs;

    public void Back()
    {
        if(!SettingsControl.isWorking)
            switch(cond)
            {
                case Condition.playing:
                    isPaused = true;
                    Time.timeScale = 0;
                    Cursor.visible = true;
                    cond = Condition.paused;
                    Alpha.On(BG, 1, true, true);
                    foreach(GameObject obj in pauseImgs)
                        Alpha.On(obj, 1, true, true);
                    break;
                case Condition.paused:
                    isPaused = false;
                    Time.timeScale = 1;
                    Cursor.visible = false;
                    cond = Condition.playing;
                    Alpha.Off(BG, 1, true, true);
                    foreach(GameObject obj in pauseImgs)
                        Alpha.Off(obj, 1, true, false);
                    break;
                case Condition.options:
                    cond = Condition.paused;
                    foreach(GameObject obj in pauseImgs)
                        Alpha.On(obj, 1, true, true);
                    foreach(GameObject obj in optionsImgs)
                        Alpha.Off(obj, 1, true, false);
                    break;
            }
    }

    public void ToOptions()
    {
        cond = Condition.options;
        foreach(GameObject obj in pauseImgs)
            Alpha.Off(obj, 1, true, false);
        foreach(GameObject obj in optionsImgs)
            Alpha.On(obj, 1, true, true);
    }

    public void Exit(){
        Application.Quit();
    }

    void Start()
    {
        Cursor.visible = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Back();
    }
}