using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    Animator animator;
    public float speed = 12.0f;
    public float gravity = -9.81f;

    public float groundDistance = 0.4f;
    public Transform groundCheck;
    public LayerMask groundMask;

    bool isGrounded;
    float walking = 0f;
    public float walk_st = 1.0f;
    public float walk_ed = 1.0f;

    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        velocity.y += gravity * Time.deltaTime;

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if(walking < 1)
            {
                walking += walk_st * Time.deltaTime;
            }
        }
        else
        {
            if(walking > 0)
            {
                walking -= walk_ed *Time.deltaTime;
            }
        }
        animator.SetFloat("Walking", walking);  
        controller.Move(speed * Time.deltaTime * move);
        controller.Move(velocity * Time.deltaTime);

    }
}
