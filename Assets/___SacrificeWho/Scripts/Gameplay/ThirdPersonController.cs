using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    internal Animator anim;
    [SerializeField] public Transform player;
    [SerializeField] public CharacterController controller;
    [SerializeField] float speed = 6.0f;
    [SerializeField] float turnSmoothTime = 0.1f;
    [SerializeField] Vector3SO movement;
    [SerializeField]internal bool isActive = false;
    float turnSmoothVelcocity;
    float horizontal;
    float vertical;
    Vector3 forward;
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        if(isActive)
        {
        Move();
        }
    }

    void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        if (player != null)
        {
            forward = player.TransformDirection(Vector3.forward);
            Debug.Log(isWalking);    
            anim.SetBool("isRunning", isWalking);
        }
    }
    void OnAnimatorMove()
    {
        player.Rotate(0, horizontal * turnSmoothTime * Time.deltaTime, 0);
        controller.Move(forward * Mathf.Max(vertical, 0) * speed * Time.deltaTime);
    }
}