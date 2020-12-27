using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsLanguageSave : MonoBehaviour
{
    static string SavePath;
    Language L = new Language();

    public void ChangeLanguage(string language)
    {
        L.language = language;
    }

    public void Apply()
    {
        File.WriteAllText(SavePath, JsonUtility.ToJson(L));
        SettingsLanguage.language = L.language;
    }

    void Start()
    {
        SavePath = Path.Combine(Application.dataPath + "/Saves", "Language.json");

        if (!File.Exists(SavePath))
            File.WriteAllText(SavePath, JsonUtility.ToJson(L));
        L = JsonUtility.FromJson<Language>(File.ReadAllText(SavePath));
        Apply();
    }

    [Serializable]
    public class Language
    {
        public string language;
    }
}