using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsControlSave : MonoBehaviour
{
    static string SavePath;
    Control C = new Control();
    KeyCode key;

    void OnGUI()
    {
        if (Input.GetKey(KeyCode.LeftShift)) { key = KeyCode.LeftShift; }
        else
        {
            if (Input.anyKey)
            {
                Event e = Event.current;
                if (e.isKey && e.keyCode != KeyCode.None) { key = e.keyCode; }
            }
        }
    }

    public void Apply()
    {
        C = JsonUtility.FromJson<Control>(File.ReadAllText(SavePath));
        SettingsControl.up = C.up;
        SettingsControl.down = C.down;
        SettingsControl.right = C.right;
        SettingsControl.left = C.left;
        SettingsControl.jump = C.jump;
        SettingsControl.dash = C.dash;
        SettingsControl.active = C.active;
    }

    void Start()
    {
        SavePath = Path.Combine(Application.dataPath + "/Saves", "Control.json");

        if (!File.Exists(SavePath))
            File.WriteAllText(SavePath, JsonUtility.ToJson(C));
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