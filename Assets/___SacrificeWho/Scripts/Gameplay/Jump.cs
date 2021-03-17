using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]public CharacterController controller;

    [SerializeField] bool isGrounded;
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask groundmask;
    [SerializeField] float gravity;

    [SerializeField] float jumpHeight;

    Animator anim;

    Vector3 velocity;


    void Start()
    {
        controller = GetComponentInChildren<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundmask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //if (isGrounded)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
                
        //        JumpAction();
        //    }
        //}

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void JumpAction()
    {
        anim.SetBool("isRunning", false);
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
}
