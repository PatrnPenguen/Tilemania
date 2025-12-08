using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    Animator animator;
    
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpForce = 15f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>(); 
    }

    void OnJump(InputValue value)
    {
        rb.linearVelocity += new Vector2(0, jumpForce);
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x*runSpeed, rb.linearVelocity.y);
        rb.linearVelocity = playerVelocity;
        animator.SetBool("isRunning", Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon);
    }

    void FlipSprite()
    {
       bool hasHorizontalSpeed = Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon;
       if (hasHorizontalSpeed)
       {
           transform.localScale = new Vector2(Mathf.Sign(rb.linearVelocity.x), 1f);
       }
    }

    
}
