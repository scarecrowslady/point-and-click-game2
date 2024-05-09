using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject escapePanel;

    // Start is called before the first frame update
    void Start()
    {
        escapePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void UnPauseGame()
    {
        Time.timeScale = 1.0f;
    }
    
    public void ExitButton()
    {        
        SaveManager.Instance.SaveInfo();

        SceneManager.LoadScene("Menu");
    }
}