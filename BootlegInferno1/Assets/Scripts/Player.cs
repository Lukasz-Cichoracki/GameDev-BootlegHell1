using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : InputProvider
{

    public static Player Instance { get; private set; }

    private Rigidbody2D playerRigidbody;
    private BoxCollider2D playerBoxCollider;

    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private float movementSpeed = 3f;

    private bool isTurnedRight;

    private void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("Player Instance Not Null!");
        }
        Instance = this;

        playerRigidbody = GetComponent<Rigidbody2D>();
        playerBoxCollider = GetComponent<BoxCollider2D>();

        playerInputActions.Player.Jump.performed += Jump;
    }

    private void FixedUpdate()
    {
        Vector2 movementVector2D = new Vector2();
        float moveDirection = playerInputActions.Player.Move.ReadValue<float>();

        movementVector2D.x = moveDirection * movementSpeed;

        playerRigidbody.velocity += movementVector2D;

        if (moveDirection != 0)
        {
            TurnPlayer(moveDirection < 1f);
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if(isGrounded())
        {
            Vector2 jumpVector2D = new Vector2(0f, 1f * jumpForce);
            if (context.performed)
                playerRigidbody.velocity += jumpVector2D;
        }
    }

    private void TurnPlayer(bool isTurnedRight)
    {
        if (this.isTurnedRight == isTurnedRight)
            return;

        Vector3 playerScale = playerRigidbody.transform.localScale;

        playerRigidbody.transform.localScale = new Vector3(playerScale.x * -1, playerScale.y, playerScale.z);
        this.isTurnedRight = isTurnedRight;
    }

    private bool isGrounded()
    {
        float extraHeightTest = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(playerBoxCollider.bounds.center, Vector2.down, playerBoxCollider.bounds.extents.y+extraHeightTest,platformLayerMask);
        return raycastHit;
    }
}
