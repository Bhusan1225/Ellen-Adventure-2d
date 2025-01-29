using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{
    //singleton
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    [SerializeField] private string[] Levels;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }


    private void Start()
    {
        if (GetLevelStatus(Levels[0]) == LevelStatus.Locked )
        {
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
        }
    }

    public void MarkCurrentLevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        //set level status to complete 
        
        SetLevelStatus(currentScene.name, LevelStatus.Completed);

        int currentSceneIndex = Array.FindIndex(Levels, level => level == currentScene.name);
        int nextSceneIndex = currentSceneIndex + 1;
        if (Levels.Length > nextSceneIndex)
        {
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
        }
    }
    public LevelStatus GetLevelStatus(string level)    
    {
        //logic
        LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
        Debug.Log("setting Level:" + level + "Status" + levelStatus);
    }









}
