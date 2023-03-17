using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour, PlayerInputs.IPlayerActionsActions
{
    [SerializeField] float movementSpeed;

    Vector2 moveInput;

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
        rb.velocity = moveInput * movementSpeed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        input.y = 0;
        moveInput = input;

    }
}
