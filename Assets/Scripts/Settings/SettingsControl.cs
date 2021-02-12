﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsControl : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject blackScreen;
    [SerializeField] GameObject[] SCUI;
    static string SavePath;
    Control C = new Control();
    KeyCode key, lastKey;
    Color red = new Color(1, 0, 0);

    void OnGUI()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            key = KeyCode.LeftShift;
        else
        {
            if (Input.anyKey)
            {
                Event e = Event.current;
                if (e.isKey && e.keyCode != KeyCode.None)
                    key = e.keyCode;
            }
        }
    }

    IEnumerator CC(string name)
    {
        while (true)
        {
            if (Input.anyKey)
            {
                if (key != KeyCode.Escape && key != lastKey)
                {
                    switch (name)
                    {
                        case "up":
                            C.up = key;
                            SCUI[0].GetComponent<Text>().text = $"[{key}]";
                            SCUI[0].GetComponent<Text>().color = red;
                            break;
                        case "down":
                            C.down = key;
                            SCUI[1].GetComponent<Text>().text = $"[{key}]";
                            SCUI[1].GetComponent<Text>().color = red;
                            break;
                        case "right":
                            C.right = key;
                            SCUI[2].GetComponent<Text>().text = $"[{key}]";
                            SCUI[2].GetComponent<Text>().color = red;
                            break;
                        case "left":
                            C.left = key;
                            SCUI[3].GetComponent<Text>().text = $"[{key}]";
                            SCUI[3].GetComponent<Text>().color = red;
                            break;
                        case "jump":
                            C.jump = key;
                            SCUI[4].GetComponent<Text>().text = $"[{key}]";
                            SCUI[4].GetComponent<Text>().color = red;
                            break;
                        case "dash":
                            C.dash = key;
                            // SCUI[5].GetComponent<Text>().text = $"[{key}]";
                            // SCUI[5].GetComponent<Text>().color = red;
                            break;
                        case "active":
                            C.active = key;
                            SCUI[5].GetComponent<Text>().text = $"[{key}]";
                            SCUI[5].GetComponent<Text>().color = red;
                            break;
                    }
                    lastKey = key;
                    break;
                }
                else
                    break;
            }
            yield return null;
        }
        Alpha.Off(blackScreen, 1, true, false);
    }

    public void ChangeControl(string name)
    {
        StartCoroutine("CC", name);
        // SCUI[0].GetComponent<Button>().Interactable = false;
        Alpha.On(blackScreen, 1, true, true);
    }

    public void Apply()
    {
        File.WriteAllText(SavePath, JsonUtility.ToJson(C));
        Settings.up = C.up;
        Settings.down = C.down;
        Settings.right = C.right;
        Settings.left = C.left;
        Settings.jump = C.jump;
        Settings.dash = C.dash;
        Settings.active = C.active;
    }

    async void Start()
    {
        await Task.Delay(1);
        SavePath = Path.Combine(Application.dataPath + "/Saves", "Control.json");

        if (!File.Exists(SavePath))
            File.WriteAllText(SavePath, JsonUtility.ToJson(C));
        C = JsonUtility.FromJson<Control>(File.ReadAllText(SavePath));
        Apply();
    }

    [Serializable]
    public class Control
    {
        public KeyCode up = KeyCode.W;
        public KeyCode down = KeyCode.S;
        public KeyCode right = KeyCode.D;
        public KeyCode left = KeyCode.A;
        public KeyCode jump = KeyCode.Space;
        public KeyCode dash = KeyCode.LeftShift;
        public KeyCode active = KeyCode.E;
    }
}