using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDifficulty : MonoBehaviour
{
    public enum Difficulties { Easy, Medium, Hard };

    public Toggle tg1;
    public Toggle tg2;
    public Toggle tg3;

    public static Difficulties difficulty = Difficulties.Easy;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("LevelDiff") == 1)
        {
            tg1.isOn = true;
        }
        else if (PlayerPrefs.GetInt("LevelDiff") == 2)
        {
            tg2.isOn = true;
        }
        else if (PlayerPrefs.GetInt("LevelDiff") == 3)
        {
            tg3.isOn = true;
        }
    }
    public void SetDifficulty(int i)
    {
        PlayerPrefs.SetInt("LevelDiff", i);
    }
}
