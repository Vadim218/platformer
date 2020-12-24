using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Resume()
    
    {
        Time.timeScale = 1f;


    }

    public async void Off(GameObject image, int Delay)
    {
        float A = 255;
        for (int i = 255; i > 0; i--)
        {
            A--;
            image.GetComponent<Image>().color = new Color(1f, 1f, 1f, A / 255);
            await Task.Delay(Delay);

        }
        //Image.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
    }
}
