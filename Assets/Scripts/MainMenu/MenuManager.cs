using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    #region Manage Game States
    public void StartNewGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadGame()
    {
        if (SaveManager.Instance.isGameSaved == false)
        {
            Debug.Log("there is no saved game");
        }
        else
        {
            SaveManager.Instance.LoadInfo();

            SceneManager.LoadScene("Game");
        }        
    }
    #endregion

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
