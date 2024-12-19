using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class LobbyController : MonoBehaviour
{
    public Button Playbutton;
    public Button quitbutton;
   
    public GameObject playCanvas;
    public GameObject QuitPanel;

    public GameObject ChooseLevelpopup;
    private void Awake()
    {
        Playbutton.onClick.AddListener(PlayGame);
        quitbutton.onClick.AddListener(ThanksPanal);
    }

    private void ThanksPanal()
    {
        playCanvas.SetActive(false);
        QuitPanel.SetActive(true);
        
    }

    private void PlayGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        ChooseLevelpopup.SetActive(true);
        
    }
}
