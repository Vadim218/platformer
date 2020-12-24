using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
public class ui : MonoBehaviour
{
    public GameObject imege1;
    public GameObject imege2;
    public GameObject imege3;
    public GameObject imege4;
    public bool port;
    public void ghg()
    {
        if (!port)
        {
            On(imege1, 1);
            On(imege2, 1);
            On(imege3, 1);
            On(imege4, 1);
            port = true;

        }
        else
        {
            Off(imege1, 1);
            Off(imege2, 1);
            Off(imege3, 1);
            Off(imege4, 1);
            port = false;
        }
        Debug.Log("forko");
    }

    

    // Start is called before the first frame update
    void Start()
    {
        Off(imege1, 0);
        Off(imege2, 0);
        Off(imege3, 0);
        Off(imege4, 0);
        port = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            ghg();

        }

    }
    public async void On(GameObject image, int Delay)
    {
        float A = 0;
        for (int i = 0; i < 255; i++)
        {
            A++;
            image.GetComponent<Image>().color = new Color(1f, 1f, 1f, A / 255);
            await Task.Delay(Delay);
            
        }
        //Image.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
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
