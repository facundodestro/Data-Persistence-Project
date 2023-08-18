using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public string playerTextToSave;
    public Text text;
    public int highScore;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadTextWritten();
        highScore = PlayerPrefs.GetInt("MaxScore");
    }



    [System.Serializable]
    class SaveData
    {
        public string playerTextToSave;
        public int highScore;
    }
    public void SaveTextWritten()
    {
        playerTextToSave = text.text;
        SaveData data = new SaveData();
        data.playerTextToSave = playerTextToSave;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        //Application.persistentDataPath in Windows points to a folder in Appdata/LocalLow/<Company Name>
    }

    public void LoadTextWritten()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerTextToSave = data.playerTextToSave;
            highScore = data.highScore;
        }
    }

    public void ResetHighScore()
    {
        highScore = 0;
        PlayerPrefs.SetInt("MaxScore", 0);
    }
}
