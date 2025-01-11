using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;

    [SerializeField] public float speed = 12f;

    [SerializeField] private float gravity = -9.81f;

    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;

    bool isGrounded;

    Vector3 velocity;

    [SerializeField] private float FuerzaSalto = 3;

    public bool isSprinting;

    public float sprintingSpeedMultiplier = 1.5f;

    private float sprintSpeed = 1;
    void Start()
    {
        
    }


    void Update()
    {

        AplicarGravedad();

        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");

        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(FuerzaSalto * -2 * gravity);  
        }

        RunCheck();

        CheckJump();

        characterController.Move(move * speed * Time.deltaTime * sprintSpeed);
    }

    public void CheckJump()
    {

    }

    private void AplicarGravedad()
    {
        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }

    public void RunCheck()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = !isSprinting;
        }

        if (isSprinting ==true) 
        {
            sprintSpeed = sprintingSpeedMultiplier;
        }

        else
        {
            sprintSpeed = 1;
        }
    }
}
