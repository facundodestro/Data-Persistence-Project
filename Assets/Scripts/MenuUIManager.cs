using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIManager : MonoBehaviour
{
    public static MenuUIManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void NewTextWritten(string istring)
    {
        // add code here to handle when a color is selected
        MenuManager.Instance.playerTextToSave = istring;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void SaveTextWritten()
    {
        MenuManager.Instance.SaveTextWritten();
    }

    public void LoadTextWritten()
    {
        MenuManager.Instance.LoadTextWritten();
    }

    public void ResetHighScore()
    {
        MenuManager.Instance.ResetHighScore();
    }
}
