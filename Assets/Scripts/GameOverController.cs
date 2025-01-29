using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{

    [SerializeField] private Button RestartButton;
    [SerializeField] private Button QuitButton;

    [SerializeField] private GameObject GameOverPanel;
  
    public void Awake()
    {
        RestartButton.onClick.AddListener(reloadLevel);
        QuitButton.onClick.AddListener(showMainMenu);
    }

    private void showMainMenu()
    {
 
        SceneManager.LoadScene(0);
    }

    public void onPlayerDeath()
    {
        SoundManager.Instance.Play(Sounds.PlayerDeath);
        gameObject.SetActive(true);
    }


    public void reloadLevel()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    
} 
