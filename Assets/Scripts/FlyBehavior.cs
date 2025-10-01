using UnityEngine;
using UnityEngine.InputSystem;

public class FlyBehavior : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float jumpForce = 5f; 
    [SerializeField] private float gravityScale = 2f;
    [SerializeField] private float rotationSpeed = 5f;

    private Rigidbody2D rb;
    private Jump inputActions;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputActions = new Jump();
    }

    private void OnEnable()
    {
        inputActions.Touch.Jump.started += OnJump;
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Touch.Jump.started -= OnJump;
        inputActions.Disable();
    }

    private void Start()
    {
        rb.gravityScale = gravityScale;
        Application.targetFrameRate = 60;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.linearVelocity.y * rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
    }
}
