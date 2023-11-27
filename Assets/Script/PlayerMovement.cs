
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;

    private Vector2 direction = Vector2.down;
    public float speed = 5f;
    private Rigidbody2D rb;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()   
    {
        if (Input.GetKey(inputUp))
        {
            SetDirection(Vector2.up);
        }
        else if (Input.GetKey(inputDown))
        {
            SetDirection(Vector2.down);
        }
        else if (Input.GetKey(inputLeft))
        {
            SetDirection(Vector2.left);
        }
        else if (Input.GetKey(inputRight))
        {
            SetDirection(Vector2.right);
        }
        else
        {
            SetDirection(Vector2.zero);
        }
    }

    private void FixedUpdate()
    {
      
        rb.velocity = direction * speed;
    }

    private  void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
        if(newDirection != Vector2.zero)
        {
            animator.SetFloat("X", newDirection.x);
            animator.SetFloat("Y", newDirection.y);
            animator.SetBool("isMove", true);
        }
        else
        {
            animator.SetBool("isMove", false);
        }
    }
}
