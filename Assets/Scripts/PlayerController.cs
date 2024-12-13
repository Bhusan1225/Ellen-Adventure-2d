using UnityEngine;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{

    public Animator animator;
    public float speed;

    public BoxCollider2D boxCollider;


    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playercontroller();
        plaverCrouch();
        playerJumpanimation();


    }

    private void playercontroller()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        playerMovementAnimation(horizontal);
        playerMovement(horizontal);


    }
    void playerMovement(float horizontal)
    {

        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        
        transform.position = position;
        //gameObject.transform.position.x = position.x +horizontal*speed;
    }

    private void playerMovementAnimation(float horizontal)
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

        transform.localScale = scale;//it kind of RHS =LHS
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

    void playerJumpanimation()
    {
        float jump = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Jump", jump);

    }
}
