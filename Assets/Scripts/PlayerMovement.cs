using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rigidbody;
    public InputAction playerControl;
    private Vector2 moveDirection;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerControl.Enable();
    }

    private void OnDisable()
    {
        playerControl.Disable();
    }

    private void FixedUpdate()
    {
        moveDirection = playerControl.ReadValue<Vector2>();
        rigidbody.MovePosition(rigidbody.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
