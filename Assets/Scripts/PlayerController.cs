using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;


public class PlayerController : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;

    [SerializeField] private int health = 3;
    [SerializeField] private TextMeshProUGUI healthText;

    [SerializeField] private BoxCollider2D boxCollider;
    private Rigidbody2D rigidBody;

    [SerializeField] private ScoreController scoreController;
    [SerializeField] private GameOverController gameOverController;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInput();
   
    }
    
    public void playerDeathAnimation()
    {
        animator.SetBool("p_Death", true);
    }

    private void playerInput()
    {
        //input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        playerMovementAnimation(horizontal, vertical);
        playerMovement(horizontal,vertical);
   
    }

    void playerMovement(float horizontal, float vertical)
    {

        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        
        transform.position = position;
       

        if (vertical > 0)
        {
            rigidBody.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);

        }
    }

    private void playerMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {

            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else
        {

            scale.x = Mathf.Abs(scale.x);

        }

        transform.localScale = scale;//it's kind of RHS =LHS

        //player jump animation
        if (vertical > 0f)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    
    internal void pickUpKey()
    {
        Debug.Log("Player got one point.");
        scoreController.IncreaseScore(20);
    }

    internal void damagePlayer()
    {
        Debug.Log("Player got damage.");
        Debug.Log("health reduced.");
        if (health > 0 && health <= 3)
        {
            health = health - 1;
            healthText.text = "health:" + health;

        }
        else
        {
            playerDeathAnimation();
            gameOverController.onPlayerDeath();

            this.enabled = false;
 

        }

    }

}