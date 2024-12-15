using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enmeyController : MonoBehaviour
{

    public float patrolSpeed = 2f;
    public Vector3 pointA;
    public Vector3 pointB;
    private Vector3 targetPoint;
    public Animator animator;

    private void Start()
    {
        SetPatrolPoints();
        
    }


    private void Update()
    {

        PatrolEnmey();
        //e_animator = GetComponent<Animator>();
    }
    private void SetPatrolPoints()
    {
        transform.position = pointA;
        targetPoint = pointB;
               
    }

    private void PatrolEnmey()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, patrolSpeed * Time.deltaTime);
        if (transform.position == targetPoint)
        {
            targetPoint = (targetPoint == pointA) ? pointB : pointA;
            
            enmeyRotation();
            
        } 
    }

    void enmeyRotation()
    {
        Vector3 scale = transform.localScale;
        if (targetPoint == pointB)
        {
            
            scale.x =  Mathf.Abs(scale.x);

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
            playerController.killPlayer();



            //e_animator.SetBool("Attack", true);



        }
    }


   
         


    
}
