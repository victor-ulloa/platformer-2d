using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour, PlayerInputs.IPlayerActionsActions
{
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpForce;

    float moveInput;

    PlayerInputs playerInputs;
    Rigidbody2D rb;
    // Start is called before the first frame update

    private void Awake()
    {
        playerInputs = new PlayerInputs();
        rb = GetComponent<Rigidbody2D>();
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

    void Start()
    {

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        moveInput = input.x * movementSpeed;

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
        }

    }
}
