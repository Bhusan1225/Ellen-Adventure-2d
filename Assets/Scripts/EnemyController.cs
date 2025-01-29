using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{

    public float patrolSpeed = 2f;
    public Vector3 pointA;
    public Vector3 pointB;
    private Vector3 targetPoint;
    public Animator animator;

    private void Start()
    {
        setPatrolPoints();
        
    }


    private void Update()
    {

        enemyPatrolling();
    }
    private void setPatrolPoints()
    {
        transform.position = pointA;
        targetPoint = pointB;
               
    }

    private void enemyPatrolling()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, patrolSpeed * Time.deltaTime);
        if (transform.position == targetPoint)
        {
            targetPoint = (targetPoint == pointA) ? pointB : pointA; //this will take care of the enemy patrolling 
            
            enemyRotation();// this will take care of when the enmey reaches to the point B the he changes the face
            
        } 
    }

    void enemyRotation()
    {
        Vector3 scale = transform.localScale;
        if (targetPoint == pointB)
        {
            
            scale.x = Mathf.Abs(scale.x);

        }
        else
        {
            
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {

            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.damagePlayer();

            //e_animator.SetBool("Attack", true);

        }
    }


   
         


    
}
