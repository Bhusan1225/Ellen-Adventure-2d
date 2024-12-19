using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class LevelOverController : MonoBehaviour
{

    public GameObject LevelOverPanel;
    public Button restartButton;
    public Button nextLevelButton;
    public string NextSceneName;

    
    public TextMeshProUGUI levelText;

    private void Start()
    {
        restartButton.onClick.AddListener(RestartCurrentLevel);
        nextLevelButton.onClick.AddListener(LoadNextLevel);
    }

    private void LoadNextLevel()
    {

        //SceneManager.LoadScene(NextSceneName);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    private void RestartCurrentLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>()!= null)
       
            //game Over logic
            Debug.Log("Level complete");
        
            LevelManager.Instance.MarkcurrentLevelComplete();
           LevelOverPanel.SetActive(true);
          

            
        }
    }


    




