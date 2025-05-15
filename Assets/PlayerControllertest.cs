using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float crouchSpeed = 2f;
    public float crawlSpeed = 1.5f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private int jumpCount = 0;
    private bool isCrouching = false;
    private bool isCrawling = false;
    private float originalHeight;

    public float crouchHeight = 1f;
    public float crawlHeight = 0.5f;

    [HideInInspector] public float currentSpeed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        originalHeight = controller.height;
        currentSpeed = walkSpeed; // Inicializamos con velocidad de caminar
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
            jumpCount = 0; // Reset salto doble al tocar el suelo
        }
    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * currentSpeed * Time.deltaTime);

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