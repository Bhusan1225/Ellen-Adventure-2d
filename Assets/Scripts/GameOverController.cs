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
    public GameObject quitPanel;
    
    public string sceneName;

    public void Awake()
    {
        RestartButton.onClick.AddListener(ReloadLevel);
        QuitButton.onClick.AddListener(Thanksplaying);
    }

    private void Thanksplaying()
    {
        //GameOverPanel.SetActive(false);
        //quitPanel.SetActive(true);
        SceneManager.LoadScene(0);
    }

    public void playerDied()
    {
        gameObject.SetActive(true);
    }


    public void ReloadLevel()
    {
        Debug.Log("load scene 0.");
        SceneManager.LoadScene(sceneName);
    }
    //done with the restart Button
} 
