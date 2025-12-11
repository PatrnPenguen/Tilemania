using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    Animator animator;
    
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpForce = 18f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] float gravity = 8f;
    
    CapsuleCollider2D capsule;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsule = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        Run();
        ClimbLadder();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>(); 
        Debug.Log(moveInput);
    }

    void OnJump(InputValue value)
    {
        if (!capsule.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return;}
        if (value.isPressed)
        {
            rb.linearVelocity += new Vector2(0, jumpForce);
        }
    }

    void Run()
    {
        Vector2 playerHorizontalVelocity = new Vector2(moveInput.x*runSpeed, rb.linearVelocity.y);
        rb.linearVelocity = playerHorizontalVelocity;
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

    void ClimbLadder()
    {
        if (!capsule.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            animator.SetBool("isClimbing", false);
            rb.gravityScale = gravity;
            return;
        }
        
        rb.gravityScale = 0;
        Vector2 playerVerticalVelocity = new Vector2(rb.linearVelocity.x, moveInput.y*climbSpeed);
        rb.linearVelocity = playerVerticalVelocity;
        animator.SetBool("isClimbing", Mathf.Abs(rb.linearVelocity.y) > Mathf.Epsilon);
    }
}
