using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public static class Alpha
{
    public static async void On(GameObject image, int delay)
    {
        float A = 0;
        for (int i = 0; i < 255; i++)
        {
            A++;
            if (image.GetComponent<Image>())
                image.GetComponent<Image>().color = new Color(1f, 1f, 1f, A / 255);
            if (image.GetComponent<SpriteRenderer>())
                image.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, A / 255);
            if (image.GetComponent<Text>())
                image.GetComponent<Text>().color = new Color(1f, 1f, 1f, A / 255);
            if (image.GetComponent<TextMesh>())
                image.GetComponent<TextMesh>().color = new Color(1f, 1f, 1f, A / 255);
            await Task.Delay(delay);
        }
    }

    public static async void Off(GameObject image, int delay)
    {
        float A = 255;
        for (int i = 255; i > 0; i--)
        {
            A--;
            if (image.GetComponent<Image>())
                image.GetComponent<Image>().color = new Color(1f, 1f, 1f, A / 255);
            if (image.GetComponent<SpriteRenderer>())
                image.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, A / 255);
            if (image.GetComponent<Text>())
                image.GetComponent<Text>().color = new Color(1f, 1f, 1f, A / 255);
            if (image.GetComponent<TextMesh>())
                image.GetComponent<TextMesh>().color = new Color(1f, 1f, 1f, A / 255);
            await Task.Delay(delay);
        }
    }

    public static async void On(GameObject image, int delay, bool destroyOnEnd)
    {
        On(image, delay);
        for (int i = 255; i > 0; i--)
            await Task.Delay(delay);
        if(destroyOnEnd)
            MonoBehaviour.Destroy(image);
    }

    public static async void Off(GameObject image, int delay, bool destroyOnEnd)
    {
        Off(image, delay);
        for (int i = 255; i > 0; i--)
            await Task.Delay(delay);
        if(destroyOnEnd)
            MonoBehaviour.Destroy(image);
    }

    public static async void On(GameObject image, int delay, bool setActiveOnStart, bool setActiveOnEnd)
    {
        image.SetActive(setActiveOnStart);
        On(image, delay);
        for (int i = 255; i > 0; i--)
            await Task.Delay(delay);
        image.SetActive(setActiveOnEnd);
    }

    public static async void Off(GameObject image, int delay, bool setActiveOnStart, bool setActiveOnEnd)
    {
        image.SetActive(setActiveOnStart);
        Off(image, delay);
        for (int i = 255; i > 0; i--)
            await Task.Delay(delay);
        image.SetActive(setActiveOnEnd);
    }
}