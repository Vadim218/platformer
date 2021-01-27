using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System;
using UnityEngine;

public class SettingsControl : MonoBehaviour
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

    IEnumerator CC(string name)
    {
        while (true)
        {
            if (Input.anyKey)
            {
                if (key != KeyCode.Escape)
                {
                    yield return new WaitForSeconds(0.01f);
                    switch (name)
                    {
                        case "up":
                            C.up = key;
                            break;
                        case "down":
                            C.down = key;
                            break;
                        case "right":
                            C.right = key;
                            break;
                        case "left":
                            C.left = key;
                            break;
                        case "jump":
                            C.jump = key;
                            break;
                        case "dash":
                            C.dash = key;
                            break;
                        case "active":
                            C.active = key;
                            break;
                    }
                    break;
                }
                else
                    break;
            }
            yield return null;
        }
    }

    public void ChangeControl(string name)
    {
        StartCoroutine("CC", name);
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