using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enmeyController : MonoBehaviour
{

    public float patrolSpeed = 2f;
    public Vector3 pointA;
    public Vector3 pointB;
    private Vector3 targetPoint;
    public Animator e_animator;

    private void Start()
    {
        SetPatrolPoints();
    }
    
    
    private void Update()
    {

        PatrolEnmey();
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
            e_animator.SetBool("Attack", true);
        }
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
