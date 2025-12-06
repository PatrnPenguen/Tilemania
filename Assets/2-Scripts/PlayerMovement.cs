using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    
    [SerializeField] float runSpeed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Run();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>(); 
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x*runSpeed, rb.linearVelocity.y);
        rb.linearVelocity = playerVelocity;
        
    }
}
