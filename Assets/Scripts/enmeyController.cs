using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enmeyController : MonoBehaviour
{
    private Animator e_animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {

            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.killPlayer();



            e_animator.SetBool("Attack", true);



        }
    }

    
}
