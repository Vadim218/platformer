using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public static class Alpha
{
    public static async void On(GameObject Image, int Delay)
    {
        float A = 0;
        for (int i = 0; i < 255; i++)
        {
            A++;
            Image.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, A / 255);
            await Task.Delay(Delay);
        }
        //Image.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
    }

    public static async void Off(GameObject Image, int Delay)
    {
        float A = 255;
        for (int i = 255; i > 0; i--)
        {
            A--;
            Image.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, A / 255);
            await Task.Delay(Delay);
        }
        //Image.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
    }
}
