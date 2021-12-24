using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{

    public Text text;
    
    private void Awake()
    {
        text.text = "Level: " + LevelIndex.ToString();
    }
    public void NextLevel()
    {
        LevelIndex++;
        text.text = "Level: " + LevelIndex.ToString();
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string LevelIndexKey = "LevelIndex";
}
