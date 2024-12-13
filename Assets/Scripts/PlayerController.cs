using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public Animator animator;

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
        playerJump();


    }

    private void playercontroller()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));



        Vector3 scale = transform.localScale;
        if (speed < 0)
        {

            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else
        {

            scale.x = Mathf.Abs(scale.x);

        }

        transform.localScale = scale;
        //This updates the character’s size and direction in the game.
        //If scale.x = -1f, the character flips left.
        //If scale.x = 1f, the character flips right.
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

    void playerJump()
    {
        float jump = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Jump", jump);

    }
}
