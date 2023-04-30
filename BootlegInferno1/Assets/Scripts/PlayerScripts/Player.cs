using UnityEngine;
using UnityEngine.InputSystem;

public class Player : InputProvider
{
    public static Player Instance { get; private set; }

    [SerializeField]private Rigidbody2D playerRigidbody;
    private float defaultPlayerLinearDrag;
    private float defaultPlayerGravity;

    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private float jumpForce = 1f;

    public float JumpForce
    {
        get { return jumpForce; }
        set { if(value>0) jumpForce = value; }
    }

    [SerializeField] private float maxMovementSpeed = 3f;


    public float MaxMovementSpeed
    {
        get { return maxMovementSpeed; }
        set { if(value>0) maxMovementSpeed = value; }
    }


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
        defaultPlayerGravity = playerRigidbody.gravityScale;

        playerInputActions.Player.Jump.performed += Jump;

        PlayerTriggerDetection.Instance.OnDeath += PlayerTriggerDetection_OnDeath;
        
    }


    private void PlayerTriggerDetection_OnDeath(object sender, System.EventArgs e)
    {
        canMove = false;
    }

    private void FixedUpdate()
    {
        Vector2 movementVector2D = new Vector2();
        float moveDirection = playerInputActions.Player.Move.ReadValue<float>();
        float movementSpeed = maxMovementSpeed;

        IsCrouching();

        if (!IsGrounded())
            movementSpeed /= 2;

        if(!IsCrouching() && canMove)
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
        if (IsGrounded() && !IsCrouching() && !GameManager.Instance.IsPaused)
        {
            Vector2 jumpVector2D = new Vector2(0f, 1f * jumpForce);
            if (context.performed)
                playerRigidbody.velocity += jumpVector2D;
        }
    }

    private bool IsCrouching()
    {
        float isCrouching = playerInputActions.Player.Crouch.ReadValue<float>();

        if (isCrouching != 0)
        {
            
            float crouchingColliderSizeY = 2.1f; 
            float crouchingOffsetY = 3.63f;
            Vector3 crouchColliderVector = new Vector3(colliderSize.x, crouchingColliderSizeY, colliderSize.z);
            Vector3 crouchOffsetVector = new Vector3(colliderOffset.x, crouchingOffsetY, colliderOffset.z);
            
            float crouchingLinearDrag = defaultPlayerLinearDrag /20;
            float crocuhingGravity = defaultPlayerGravity + (defaultPlayerGravity * 0.2f);
            
            playerRigidbody.drag = crouchingLinearDrag;
            playerRigidbody.gravityScale = crocuhingGravity;

            playerCollider.size = crouchColliderVector;
            playerCollider.offset = crouchOffsetVector;

            return true;
                      
        }
        else
        {
            
            playerCollider.size = colliderSize;
            playerCollider.offset = colliderOffset;
            
            playerRigidbody.drag = defaultPlayerLinearDrag;
            playerRigidbody.gravityScale = defaultPlayerGravity;

            return false;
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

    private bool IsGrounded()
    {
        float extraHeightTest = 0.1f;
        Vector3 colliderReduction = new Vector3(0.1f, 0f, 0f);
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size - colliderReduction, 0f, Vector2.down, extraHeightTest, platformLayerMask);
        return raycastHit;
    }

    private void OnDisable()
    {
        playerInputActions.Player.Jump.performed -= Jump;
    }

}
