using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    public float jumpSpeed;

    public float jumpGracePeriod;
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;

    private float? lastGroundedTime;
    private float? lastButtonPressedTime;
    private Animator animator; 
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalMovement, 0, verticalMovement);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * movementSpeed;

        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            lastGroundedTime = Time.time;
        }

        if (Input.GetButtonDown("Jump"))
        {
            lastButtonPressedTime = Time.time;
        }

        if (Time.time - lastGroundedTime <= jumpGracePeriod)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -1.5f;
            if (Time.time - lastButtonPressedTime <= jumpGracePeriod)
            {
                ySpeed = jumpSpeed;
                lastButtonPressedTime = null;
                lastGroundedTime = null;
            }
            
        }
        else
        {
            characterController.stepOffset = 0f;
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);
        // transform.Translate(movementDirection * magnitude * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("IsMoving", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);    
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

    }
}
