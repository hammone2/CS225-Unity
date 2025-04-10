using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //movement
    public float walkSpeed = 5f;
    public float sprintSpeed = 8f;
    public float crouchSpeed = 2f;

    //mouse settings
    public float lookSpeedX = 2f;
    public float lookSpeedY = 2f;
    public float minY = -90f;
    public float maxY = 90f;

    //Interactivity
    public float raycastDistance = 2f;
    public LayerMask layerMask;
    public GameObject hand;
    public bool isHoldingObject = false;

    //camera rotation
    private float rotationX = 0f;

    //controller
    private CharacterController characterController;
    public Camera cam;

    //crouch settings
    private bool isCrouching = false;
    public float crouchHeight = 0.5f;
    public float standHeight = 2f;
    private float currentHeight;

    //jump settings
    public float jumpHeight = 2f;
    private float gravity = -9.8f;
    private Vector3 velocity;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        currentHeight = standHeight;

        GameManager.player = this;
    }

    private void Update()
    {
        //Movement
        MouseLook();
        Move();
        HandleCrouch();
        JumpAndGravity();

        //Interactivity
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, raycastDistance, layerMask))
            {
                if (hit.collider.gameObject.GetComponent<InteractableObject>())
                {
                    Debug.Log("Hit an interactable object: " + hit.collider.name);
                    hit.collider.gameObject.GetComponent<InteractableObject>().InteractedWith();
                }
            }
        }
    }

    private void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSpeedX;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeedY;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minY, maxY);

        cam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void Move()
    {
        float moveDirectionY = velocity.y;

        float moveDirectionX = Input.GetAxis("Horizontal") * (isCrouching ? crouchSpeed : (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed));
        float moveDirectionZ = Input.GetAxis("Vertical") * (isCrouching ? crouchSpeed : (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed));

        Vector3 move = transform.right * moveDirectionX + transform.forward * moveDirectionZ;

        velocity = new Vector3(move.x, moveDirectionY, move.z);

        characterController.Move(velocity * Time.deltaTime);
    }

    private void JumpAndGravity()
    {
        RaycastHit hit;
        float angle = 0f;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 5f))
        {
            angle = Vector3.Angle(hit.normal, Vector3.up);
            Debug.Log("Slope Angle: " + angle);

            if (angle > characterController.slopeLimit)
            {
                Debug.Log("Too steep!");
            }
        }
        
        
        if (characterController.isGrounded && angle <= characterController.slopeLimit)
        {
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
    }

    private void HandleCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && !isCrouching)
        {
            isCrouching = true;
            currentHeight = crouchHeight;
            characterController.height = currentHeight;
            cam.transform.localPosition = new Vector3(0, crouchHeight, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && isCrouching)
        {
            isCrouching = false;
            currentHeight = standHeight;
            characterController.height = currentHeight;
            cam.transform.localPosition = new Vector3(0, 0.75f, 0);
        }
    }
}
