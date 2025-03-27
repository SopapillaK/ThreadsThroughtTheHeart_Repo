using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask groundLayer;
    bool grounded;

    public Transform orientation;
    public Transform playerOBJ;
    Quaternion playerOBJRotation;
    public Animator animator;
    public bool isWalkingCheck;


    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true;
        isWalkingCheck = false;
    }

    private void Update()
    {
        // ground check
        // 0.5 is half the player objects height so in this case half of the capsules height   
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);
        if (!Input.anyKey)
            animator.SetBool("isWalking", false);

        PlayerAttack();
        MyInput();

        if (!animator.GetBool("AttackAnim"))
        {
            playerOBJRotation = playerOBJ.rotation;
        }
        else
        {
            playerOBJ.rotation = playerOBJRotation;
        }

        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

    }

    private void FixedUpdate()
    {
        if (animator.GetBool("AttackAnim"))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        else
        {
            MovePlayer();
        }
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // calc movement dir
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (Input.GetKey("w"))
        {
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKey("s"))
        {
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKey("a"))
        {
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKey("d"))
        {
            animator.SetBool("isWalking", true);
        }
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void PlayerAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("isAttacking");
        }
    }
}
