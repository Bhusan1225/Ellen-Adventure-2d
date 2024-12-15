using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using TMPro;
using System;

public class DeadLine : MonoBehaviour
{

     public string RestartSceneName;

    private void OnTriggerEnter2D(Collider2D collision )
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //game Over logic
            Debug.Log("Player is dead,restart the level");
            SceneManager.LoadScene(RestartSceneName);

        }
    }


}
