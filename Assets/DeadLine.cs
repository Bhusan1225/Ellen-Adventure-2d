using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using TMPro;
using System;

public class DeadLine : MonoBehaviour
{
    

    public GameObject gameOverCanvas;
    public Button restart_Button;

    bool isActive;
    public string RestartSceneName;

    private void OnTriggerEnter2D(Collider2D collision )
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //game Over logic
            Debug.Log("Plater dead,restart level");
            //enable canvas
            gameOverCanvas.SetActive(isActive == true);
            Debug.Log("crossed setAcitve");
            restart_Button.onClick.AddListener(restartLevel);
            Debug.Log("crossed addAddListener");


        }
    }

    


    private void restartLevel()
    {
        SceneManager.LoadScene(RestartSceneName);
    }

}
