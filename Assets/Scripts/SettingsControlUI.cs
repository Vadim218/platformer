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
        switch(con)
        {
            case Control.up:
                GetComponent<Text>().text = $"<color=#0096FF>[{Settings.up.ToString()}]</color>";
                break;
            case Control.down:
                GetComponent<Text>().text = $"<color=#0096FF>[{Settings.down.ToString()}]</color>";
                break;
            case Control.right:
                GetComponent<Text>().text = $"<color=#0096FF>[{Settings.right.ToString()}]</color>";
                break;
            case Control.left:
                GetComponent<Text>().text = $"<color=#0096FF>[{Settings.left.ToString()}]</color>";
                break;
            case Control.jump:
                GetComponent<Text>().text = $"<color=#0096FF>[{Settings.jump.ToString()}]</color>";
                break;
            case Control.dash:
                GetComponent<Text>().text = $"<color=#0096FF>[{Settings.dash.ToString()}]</color>";
                break;
            case Control.active:
                GetComponent<Text>().text = $"<color=#0096FF>[{Settings.active.ToString()}]</color>";
                break;
        }
    }

    void Start()
    {
        UpdateControl();
    }
}
