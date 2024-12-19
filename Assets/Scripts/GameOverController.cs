using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{

    public Button RestartButton;
    public Button QuitButton;

    public GameObject GameOverPanel;
    
    
    

    public void Awake()
    {
        RestartButton.onClick.AddListener(ReloadLevel);
        QuitButton.onClick.AddListener(MainMenu);
    }

    private void MainMenu()
    {
        
        SceneManager.LoadScene(0);
    }

    public void playerDied()
    {
        gameObject.SetActive(true);
    }


    public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    //done with the restart Button
} 
