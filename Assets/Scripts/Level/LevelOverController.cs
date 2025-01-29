using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class LevelOverController : MonoBehaviour
{
    [SerializeField] private GameObject levelOverPanel;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private string nextSceneName;


    private void Start()
    {
        restartButton.onClick.AddListener(restartCurrentLevel);
        nextLevelButton.onClick.AddListener(loadNextLevel);
    }

    private void loadNextLevel()
    {

        SceneManager.LoadScene(nextSceneName);
    }

    private void restartCurrentLevel()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //game Over logic
            Debug.Log("Level complete");

            LevelManager.Instance.MarkCurrentLevelComplete();
            levelOverPanel.SetActive(true);
        }
    }
}
