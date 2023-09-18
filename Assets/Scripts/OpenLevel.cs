using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLevel : MonoBehaviour
{
    public void OpenTheLevel(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }
    
    public void DiffLevel()
    {
        int i = PlayerPrefs.GetInt("LevelDiff");
        SceneManager.LoadScene(i);
    }
}
