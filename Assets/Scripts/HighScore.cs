using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }
    private void Update()
    {
        if(MenuManager.Instance != null)
        {
            text.text = "Best Score: " + MenuManager.Instance.playerTextToSave + " : " + MenuManager.Instance.highScore;
        }
    }
}
