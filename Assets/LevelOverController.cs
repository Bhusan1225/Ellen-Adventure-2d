using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Player"))
        //insteas of this try to use getComponent and
        //check the unique component in that gameObject max.
        //time it will be the script.
        if (collision.gameObject.GetComponent<PlayerController>()!= null)
        {
            //game Over logic
            Debug.Log("Level complete");
            SceneManager.LoadScene(sceneName);


        }
    }


    



}
