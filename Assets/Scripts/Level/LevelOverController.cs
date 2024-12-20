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


   

    private void Start()
    {
        restartButton.onClick.AddListener(RestartCurrentLevel);
        nextLevelButton.onClick.AddListener(LoadNextLevel);
    }

    private void LoadNextLevel()
    {

        //SceneManager.LoadScene(NextSceneName);
        
        SceneManager.LoadScene(NextSceneName);
    }

    private void RestartCurrentLevel()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)

            //game Over logic
            Debug.Log("Level complete");

        LevelManager.Instance.MarkcurrentLevelComplete();
        LevelOverPanel.SetActive(true);



    }
}
