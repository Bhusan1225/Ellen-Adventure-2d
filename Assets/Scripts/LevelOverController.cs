using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelOverController : MonoBehaviour
{
    public string sceneName;
    public TextMeshProUGUI levelText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>()!= null)
        {
            //game Over logic
            Debug.Log("Level complete");
            SceneManager.LoadScene(sceneName);

            
        }
    }


    



}
