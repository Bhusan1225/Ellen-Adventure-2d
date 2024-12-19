using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;


public class PlayerController : MonoBehaviour
{

    public Animator animator;
    public float speed;
    public float jumpheight;
    
    public int health = 3;
    public TextMeshProUGUI health_text;

    public BoxCollider2D boxCollider;
    private Rigidbody2D rb;


    public ScoreController scoreController;
    public GameOverController gameOverController;



    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        playercontroler();
        plaverCrouch();


        

    }
    
    public void playerDeathAnimation()
    {
        animator.SetBool("p_Death", true);
    }

    private void playercontroler()
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
            rb.AddForce(new Vector2(0, jumpheight), ForceMode2D.Impulse);

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

    void plaverCrouch()
    {
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        animator.SetBool("Crouch", crouch);

        Vector2 sizeofCollider = boxCollider.size;
        Vector2 offsetofCollider = boxCollider.offset;

        if (crouch == true)
        {

            sizeofCollider = new Vector2(1.2f, 1.4f);
            offsetofCollider = new Vector2(0f, 0.5f);
        }
        else
        {
            sizeofCollider = new Vector2(0.6f, 2.2f);
            offsetofCollider = new Vector2(0f, 1f);
        }

        boxCollider.size = sizeofCollider;
        boxCollider.offset = offsetofCollider;
        //This updates the character’s size and direction in the game.
        //If scale.x = -1f, the character flips left.
        //If scale.x = 1f, the character flips right.
    }

    internal void PickUptKey()
    {
        Debug.Log("Player got one point.");
        scoreController.IncreaseScore(20);
    }

    internal void DamagePlayer()
    {
        Debug.Log("Player got damage.");
        Debug.Log("health reduced.");
        if (health > 0 && health <= 3)
        {
            health = health - 1;
            health_text.text = "health:" + health;

        }
        else
        {
            playerDeathAnimation();
            gameOverController.playerDied();

            this.enabled = false;
            

        }

    }
    

}