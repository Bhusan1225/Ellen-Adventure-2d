using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyController : MonoBehaviour
{
   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.PickUptKey();
           
            Destroy(gameObject);



        }
    }
}
