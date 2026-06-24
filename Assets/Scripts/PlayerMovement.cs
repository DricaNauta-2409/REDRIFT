using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")] 
    public Transform orientation;
    public Rigidbody rb;
    public Transform groundCheck;
    public LayerMask ground;
    public Animator animator;
    
    [Header("Movement Stats")] 
    public float moveSpeed;
    public float jumpForce;

    private float _horizontalInput;
    private float _verticalInput;
    private Vector3 _moveDirection;
    
    void Update()
    {
        MyInput();

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }

        PlayerAnimation();
        
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MyInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }

    void MovePlayer()
    {
        _moveDirection = (orientation.forward * _verticalInput) + (orientation.right * _horizontalInput);
        
        rb.velocity = new Vector3(_moveDirection.x  * moveSpeed, rb.velocity.y, _moveDirection.z  * moveSpeed);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void PlayerAnimation()
    {
        if (IsGrounded())
        {
            if (_moveDirection.magnitude > 0.1f)
            {
                animator.SetInteger("State", 1);
            }
            else
            {
                animator.SetInteger("State", 0);
            }
            
            if(Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetInteger("State", 2);
            }
        }
        else
        {
            animator.SetInteger("State", 3);
        }
    }

    bool IsGrounded()
    {
        return Physics.OverlapSphere(groundCheck.position, 0.5f, ground).Length > 0;
    }
}