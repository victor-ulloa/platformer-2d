using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour, PlayerInputs.IPlayerActionsActions
{
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpForce;
    [SerializeReference] LayerMask groundLayer;
    [SerializeReference] Transform groundCheck;
    [SerializeReference] float groundCheckRadius;
    [SerializeReference] public bool facingRight = true;

    [SerializeReference] public bool isGrounded;

    float moveInput;

    PlayerInputs playerInputs;
    Rigidbody2D rb;
    Animator animator;

    private void Awake()
    {
        playerInputs = new PlayerInputs();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerInputs.PlayerActions.SetCallbacks(this);
        playerInputs.PlayerActions.Enable();
    }

    private void OnDisable()
    {
        playerInputs.PlayerActions.Disable();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animator.SetBool("isGrounded", isGrounded);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        animator.SetFloat("moveValue", Mathf.Abs(input.x));
        moveInput = input.x * movementSpeed;


        if (input.x > 0 && !facingRight)
        {
            flip();
        }
        else if (input.x < 0 && facingRight)
        {
            flip();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
        }

    }

    void flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        facingRight = !facingRight;
    }
}
