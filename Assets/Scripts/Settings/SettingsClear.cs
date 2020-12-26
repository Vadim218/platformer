using System.IO;
using UnityEngine;
using UnityEditor;

public class SettingsClear : EditorWindow
{
    [MenuItem("Edit/MySettings/Clear All")]
    public static void ClearAll()
    {
        string path = Application.dataPath + "/Saves";
        if (Directory.Exists(path))
            Directory.Delete(path);
        else
            Debug.LogError("The folder does not exist.");
    }

    [MenuItem("Edit/MySettings/Clear Language")]
    public static void ClearLabguage()
    {
        string path = Path.Combine(Application.dataPath + "/Saves", "Language.json");
        if (File.Exists(path))
            File.Delete(path);
        else
            Debug.LogError("The file does not exist.");
    }

    [MenuItem("Edit/MySettings/Clear Control")]
    public static void ClearControl()
    {
        string path = Path.Combine(Application.dataPath + "/Saves", "Control.json");
        if (File.Exists(path))
            File.Delete(path);
        else
            Debug.LogError("The file does not exist.");
    }
}
