using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private CharacterController cr;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHieght;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    private bool _isGrounded;
    private Vector3 _velocity;

    private float _horInput;
    private float _verInput;

    private void Update()
    {
        _horInput = Input.GetAxis("Horizontal");
        _verInput = Input.GetAxis("Vertical");

        CheckSphere();
        PlayerPhysics();
        PlayerMovement();
        Jump();

    }

    private void PlayerMovement()
    {
        Vector3 move = transform.right * _horInput + transform.forward * _verInput;
        bool sprintRun = Input.GetKey(KeyCode.LeftShift);
        float currentMaxSpeed = sprintRun ? sprintSpeed : moveSpeed;
        cr.Move(move * currentMaxSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpHieght * -2 * gravity);
        }
    }

    private void PlayerPhysics()
    {
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2;
        }
        _velocity.y += gravity * Time.deltaTime;
        cr.Move(_velocity * Time.deltaTime);
    }

    private void CheckSphere()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
}
