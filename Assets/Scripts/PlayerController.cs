
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));

        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            Debug.Log("speed < 0");
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else
        {
            Debug.Log("speed > 0");
            scale.x = Mathf.Abs(scale.x);

        }
        
        transform.localScale = scale;
        //This updates the character’s size and direction in the game.
        //If scale.x = -1f, the character flips left.
        //If scale.x = 1f, the character flips right.
    }
}
