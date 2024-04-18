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
    float runningSpeed = 1.5f;
    float originalSpeed = 1.0f;
    public float multiplier = 2f;
    public float greetDistance = 5.0f;
    public GameObject NPC;

    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        runningSpeed = multiplier * speed;
        originalSpeed = speed;

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

        if(Input.GetKey(KeyCode.LeftShift) & animator.GetFloat("Walking") > 0.5)
        {
            animator.SetBool("isRunning", true);
            speed = runningSpeed;
        }
        else
        {
            animator.SetBool("isRunning", false);
            speed = originalSpeed;
        }
        animator.SetFloat("Walking", walking);  
        controller.Move(speed * Time.deltaTime * move);
        controller.Move(velocity * Time.deltaTime);

        if((transform.position - NPC.transform.position).magnitude < greetDistance)
        {
            NPC.transform.LookAt(transform);
            NPC.GetComponent<Animator>().SetBool("Greet", true);
        }
        else
        {
            NPC.GetComponent<Animator>().SetBool("Greet", false);
        }

    }
}
