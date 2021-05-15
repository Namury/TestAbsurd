using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] float walkSpeed = 15.0f;
    [SerializeField] float sprintSpeed = 30.0f;
    [SerializeField] float jumpHeight= 3.0f;
    [SerializeField] float gravity = -40.0f;
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.1f;

    [SerializeField] bool lockCursor = true;

    float cameraPitch = 0.0f;
    float velocityY = 0.0f;
    CharacterController controller = null;

    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    public InteractionInputData interactionInputData;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        interactionInputData.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
        UpdateInteraction();
    }

    void UpdateMouseLook()
    {
        Vector2 MouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        cameraPitch -= MouseDelta.y * mouseSensitivity;

        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * MouseDelta.x * mouseSensitivity);

    }

    void UpdateMovement()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if (controller.isGrounded)
        {
            velocityY = 0.0f;
            if (Input.GetButtonDown("Jump"))
                velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocityY += gravity * Time.deltaTime;

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocity = velocity * sprintSpeed + Vector3.up * velocityY;
        }
        else
        {
            velocity = velocity * walkSpeed + Vector3.up * velocityY;
        }
            

        controller.Move(velocity * Time.deltaTime);
    }

    void UpdateInteraction()
    {
        interactionInputData.InteractedClicked = Input.GetKeyDown(KeyCode.E);
        interactionInputData.InteractedRelease = Input.GetKeyUp(KeyCode.E);
    }
}
