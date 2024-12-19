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
        SoundManager.Instance.Play(Sounds.PlayerDeath);
        gameObject.SetActive(true);
    }


    public void ReloadLevel()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    //done with the restart Button
} 
