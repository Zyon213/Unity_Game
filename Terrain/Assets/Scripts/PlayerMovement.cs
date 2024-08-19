using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // [SerializeField] private float maximumSpeed;
    [SerializeField]  private float rotationSpeed;
    [SerializeField]  private float jumpHeight;
    [SerializeField]  private float gravityMultiplier;
    [SerializeField]  private float jumpGracePeriod;
    [SerializeField]  private Transform cameraTransform;
    [SerializeField]  private float JumpHorizontalSpeed;
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;

    private float? lastGroundedTime;
    private float? lastButtonPressedTime;
    private Animator animator; 
    private bool isJumping;
    private bool isGrounded;

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
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            inputMagnitude /= 2;
        }

        animator.SetFloat("Input Magnitude", inputMagnitude , 0.05f, Time.deltaTime);
        // float speed =  inputMagnitude * maximumSpeed;

        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;

        movementDirection.Normalize();

        float gravity = Physics.gravity.y * gravityMultiplier;

        if (isJumping && ySpeed > 0 && Input.GetButton("Jump") == false)
        {
            gravity *= 2;
        }
        ySpeed += gravity * Time.deltaTime;

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
            animator.SetBool("IsGrounded", true);
            isGrounded = true;
            animator.SetBool("IsJumping", false);
            isJumping = false;
            animator.SetBool("IsFalling", false);

            if (Time.time - lastButtonPressedTime <= jumpGracePeriod)
            {
                ySpeed = Mathf.Sqrt(jumpHeight * -3 * gravity);
                animator.SetBool("IsJumping", true);
                isJumping = true;
                lastButtonPressedTime = null;
                lastGroundedTime = null;
            }
            
        }
        else
        {
            characterController.stepOffset = 0f;
            animator.SetBool("IsGrounded",  false);
            isGrounded = false;
            if ((isJumping && ySpeed < 0) || ySpeed < -2)
            {
                animator.SetBool("IsFalling", true);
            }
        }



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
        if (isGrounded == false)
        {
            Vector3 Rvelocity = movementDirection * inputMagnitude * JumpHorizontalSpeed;
            Rvelocity.y = ySpeed;
            characterController.Move(Rvelocity * Time.deltaTime);
        }
 

    }

    private  void OnAnimatorMove()
    {
            //   Vector3 velocity = movementDirection * speed;
         if (isGrounded)
         {

            Vector3 velocity = animator.deltaPosition;
            velocity.y = ySpeed * Time.deltaTime;

            characterController.Move(velocity );  
         }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
