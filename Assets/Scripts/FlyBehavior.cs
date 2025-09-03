using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyBehavior : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float jumpForce = 1.5f;
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
        inputActions.Touch.Jump.performed += OnJump;
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Touch.Jump.performed -= OnJump;
        inputActions.Disable();
    }

    private void Start()
    {
        rb.gravityScale = gravityScale;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 1f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.linearVelocityY * rotationSpeed);
    }
}