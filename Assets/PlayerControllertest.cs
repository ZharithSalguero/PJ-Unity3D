using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Velocidades")]
    public float walkSpeed = 5f;
    public float crouchSpeed = 2f;
    public float crawlSpeed = 1.5f;

    [Header("Salto y Gravedad")]
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    [Header("Detección de Suelo")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Header("Cámara (Cinemachine)")]
    public Transform cameraTransform;

    [Header("Alturas")]
    public float crouchHeight = 1f;
    public float crawlHeight = 0.5f;

    public float turnTime = 0.1f;

    [HideInInspector] public float currentSpeed;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private int jumpCount = 0;
    private bool isCrouching = false;
    private bool isCrawling = false;
    private float originalHeight;
    private float _turnVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        originalHeight = controller.height;
        currentSpeed = walkSpeed;
    }

    void Update()
    {
        GroundCheck();
        HandleMovement();
        HandleJump();
        HandleCrouch();
        HandleCrawl();
    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            jumpCount = 0;
        }
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (inputDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnVelocity, turnTime);
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
        }

        // Aplicar gravedad
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < 1))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpCount++;
        }
    }

    void HandleCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = !isCrouching;

            if (isCrouching)
            {
                controller.height = crouchHeight;
                currentSpeed = crouchSpeed;
            }
            else
            {
                controller.height = originalHeight;
                currentSpeed = walkSpeed;
            }
        }
    }

    void HandleCrawl()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrawling = !isCrawling;

            if (isCrawling)
            {
                controller.height = crawlHeight;
                currentSpeed = crawlSpeed;
                Debug.Log("Modo arrastrarse activado");
            }
            else
            {
                controller.height = originalHeight;
                currentSpeed = walkSpeed;
                Debug.Log("Modo arrastrarse desactivado");
            }
        }
    }
}