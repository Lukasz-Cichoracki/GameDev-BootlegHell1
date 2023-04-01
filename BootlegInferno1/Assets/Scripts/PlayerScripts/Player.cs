using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : InputProvider
{

    public static Player Instance { get; private set; }

    [SerializeField]private Rigidbody2D playerRigidbody;
    private float defaultPlayerLinearDrag;

    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private float maxMovementSpeed = 3f;

    [SerializeField]private BoxCollider2D playerBoxCollider;
    private Vector3 boxColliderSize;
    private Vector3 boxColliderOffset;

    private bool canMove = true;
    private bool isTurnedRight;

    private void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("Player Instance Not Null!");
        }
        Instance = this;

        boxColliderSize = playerBoxCollider.size;
        boxColliderOffset = playerBoxCollider.offset;

        defaultPlayerLinearDrag = playerRigidbody.drag;

        Debug.Log(boxColliderSize);
        playerInputActions.Player.Jump.performed += Jump;
        
    }


    private void FixedUpdate()
    {
        Vector2 movementVector2D = new Vector2();
        float moveDirection = playerInputActions.Player.Move.ReadValue<float>();
        float movementSpeed = maxMovementSpeed;

        Crouching();

        if (!isGrounded())
            movementSpeed /= 2;

        if(canMove)
        {
            movementVector2D.x = moveDirection * movementSpeed;

            playerRigidbody.velocity += movementVector2D;
        }
   
        if (moveDirection != 0)
        {
            TurnPlayer(moveDirection < 1f);
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded() && !Crouching())
        {
            Vector2 jumpVector2D = new Vector2(0f, 1f * jumpForce);
            if (context.performed)
                playerRigidbody.velocity += jumpVector2D;
        }
    }

    private bool Crouching()
    {
        float isCrouching = playerInputActions.Player.Crouch.ReadValue<float>();

        if (isCrouching != 0)
        {
            canMove = false;
            float crouchingColliderSizeY = boxColliderSize.y / 2;
            Vector3 crouchColliderVector = new Vector3(boxColliderSize.x, crouchingColliderSizeY, boxColliderSize.z);
            float crouchingLinearDrag = defaultPlayerLinearDrag /20;
            playerRigidbody.drag = crouchingLinearDrag;
            playerBoxCollider.size = crouchColliderVector;
            
        }
        else
        {
            canMove = true;
            playerBoxCollider.size = boxColliderSize;
            playerRigidbody.drag = defaultPlayerLinearDrag;
        }
        
        return isCrouching !=0;
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
        RaycastHit2D raycastHit = Physics2D.Raycast(playerBoxCollider.bounds.center, Vector2.down, playerBoxCollider.bounds.extents.y + extraHeightTest, platformLayerMask);
        return raycastHit;
    }

    private void OnDisable()
    {
        playerInputActions.Player.Jump.performed -= Jump;
    }
}
