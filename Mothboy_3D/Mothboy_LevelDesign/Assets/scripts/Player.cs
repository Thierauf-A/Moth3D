using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller = null;
    [SerializeField] private float gravity = 35.0f;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpAmount = 65.0f;

    //[SerializeField] private Rigidbody rb;

    [SerializeField] private Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>();

        //hide the cursor
        Cursor.visible = false;

        //lock cursor into game window
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Platform();
        //Move();
        //Jump();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;                  //turn on cursor
            Cursor.lockState = CursorLockMode.None; //release the cursor
        }
    }

    private void Platform()
    {
        //rotate camera player thingy  
        float angle = cam.eulerAngles.y; ;
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (controller.isGrounded)
        {
            moveDirection.y = 0;
            //Feed moveDirection with input.
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            //Multiply it by speed.
            moveDirection *= speed;

            //Jumping
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpAmount;

        }
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void Move()
    {

        //rotate camera player thingy  
        float angle = cam.eulerAngles.y; ;
        transform.rotation = Quaternion.Euler(0f, angle, 0f);


        Vector3 playerVelocity = Vector3.zero;
        if (controller.isGrounded)
        {
            playerVelocity.y = 0;
        }

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        direction = Vector3.ClampMagnitude(direction, 1f);

        playerVelocity.y -= gravity * Time.deltaTime;


        Vector3 finalMove = (direction * speed) + (playerVelocity.y * Vector3.up);


        controller.Move(finalMove * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction.y = jumpAmount;
            Debug.Log("Jump");
        }


    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse); //rigidbody ver
            Debug.Log("Jump");
        }
    }
}

