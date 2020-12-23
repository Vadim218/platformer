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
            if (Image.GetComponent<Image>())
                Image.GetComponent<Image>().color = new Color(1f, 1f, 1f, A / 255);
            if (Image.GetComponent<SpriteRenderer>())
                Image.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, A / 255);
            await Task.Delay(Delay);
        }
    }

    public static async void Off(GameObject Image, int Delay)
    {
        float A = 255;
        for (int i = 255; i > 0; i--)
        {
            A--;
            if (Image.GetComponent<Image>())
                Image.GetComponent<Image>().color = new Color(1f, 1f, 1f, A / 255);
            if (Image.GetComponent<SpriteRenderer>())
                Image.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, A / 255);
            await Task.Delay(Delay);
        }
    }
}
