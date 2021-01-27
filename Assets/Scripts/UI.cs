using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject[] image;
    public static bool isPaused;

    public void OnOff()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            for(int i = 0; i < image.Length; i++)
                Alpha.Off(image[i], 1, true, false);
            isPaused = !isPaused;
        }
        else
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            for (int i = 0; i < image.Length; i++)
                Alpha.On(image[i], 1, true, true);
            isPaused = !isPaused;
        }
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
            OnOff();
    }
}
