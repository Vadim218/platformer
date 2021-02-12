using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsControlUI : MonoBehaviour
{
    enum Control {up, down, right, left, jump, dash, active}
    [SerializeField] Control con;

    public void UpdateControl()
    {
        Color blue = new Color(0, 150f / 255f, 1);
        switch(con)
        {
            case Control.up:
                GetComponent<Text>().text = $"[{Settings.up.ToString()}]";
                GetComponent<Text>().color = blue;
                break;
            case Control.down:
                GetComponent<Text>().text = $"[{Settings.down.ToString()}]";
                GetComponent<Text>().color = blue;
                break;
            case Control.right:
                GetComponent<Text>().text = $"[{Settings.right.ToString()}]";
                GetComponent<Text>().color = blue;
                break;
            case Control.left:
                GetComponent<Text>().text = $"[{Settings.left.ToString()}]";
                GetComponent<Text>().color = blue;
                break;
            case Control.jump:
                GetComponent<Text>().text = $"[{Settings.jump.ToString()}]";
                GetComponent<Text>().color = blue;
                break;
            case Control.dash:
                GetComponent<Text>().text = $"[{Settings.dash.ToString()}]";
                GetComponent<Text>().color = blue;
                break;
            case Control.active:
                GetComponent<Text>().text = $"[{Settings.active.ToString()}]";
                GetComponent<Text>().color = blue;
                break;
        }
    }

    void Start()
    {
        UpdateControl();
    }
}
