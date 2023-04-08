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

    [SerializeField] private CapsuleCollider2D playerCollider;
    private Vector3 colliderSize;
    private Vector3 colliderOffset;

    private bool canMove = true;
    private bool isTurnedRight;

    private void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("Player Instance Not Null!");
        }
        Instance = this;

        colliderSize = playerCollider.size;
        colliderOffset = playerCollider.offset;

        defaultPlayerLinearDrag = playerRigidbody.drag;

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
            
            

            float crouchingColliderSizeY = 2.1f; 
            float crouchingOffsetY = 3.6f;
            Vector3 crouchColliderVector = new Vector3(colliderSize.x, crouchingColliderSizeY, colliderSize.z);
            Vector3 crouchOffsetVector = new Vector3(colliderOffset.x, crouchingOffsetY, colliderOffset.z);
            
            float crouchingLinearDrag = defaultPlayerLinearDrag /20;
            
            playerRigidbody.drag = crouchingLinearDrag;
            playerCollider.size = crouchColliderVector;
            playerCollider.offset = crouchOffsetVector;
                      
        }
        else
        {
            canMove = true;
            
            playerCollider.size = colliderSize;
            playerCollider.offset = colliderOffset;
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
        RaycastHit2D raycastHit = Physics2D.Raycast(playerCollider.bounds.center, Vector2.down, playerCollider.bounds.extents.y + extraHeightTest, platformLayerMask);
        return raycastHit;
    }

    private void OnDisable()
    {
        playerInputActions.Player.Jump.performed -= Jump;
    }
}
