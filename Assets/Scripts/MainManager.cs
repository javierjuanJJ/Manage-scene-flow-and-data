using System.Collections;
using System.Collections.Generic;
using System.IO;
using Model;
using UnityEngine;

[DefaultExecutionOrder(1)]
public class MainManager : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    private static MainManager instance;
    private Color teamColor; // new variable declared

    public static MainManager Instance => instance;

    public Color TeamColor
    {
        get => teamColor;
        set => teamColor = value;
    }
    
    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;
        
        string json = JsonUtility.ToJson(data);
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;
        }

    }

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadColor();
            Debug.Log(Instance.TeamColor);
        }
    }
}
