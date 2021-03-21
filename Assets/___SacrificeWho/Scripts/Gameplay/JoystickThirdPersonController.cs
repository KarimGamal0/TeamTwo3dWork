using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickThirdPersonController : MonoBehaviour
{
    internal Animator anim;
    [SerializeField]internal bool isActive = false;
    [SerializeField] public Transform player;
    [SerializeField] public CharacterController controller;
    [SerializeField] Camera cam;
    [SerializeField] float speed = 6.0f;
    [SerializeField] float turnSmoothTime = 0.1f;
    [SerializeField] Vector3SO movement;
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
        bool hasHorizontalInput = !Mathf.Approximately(movement.value.z, 0f);
        bool hasVerticalInput = !Mathf.Approximately(movement.value.x, 0f);
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
        Quaternion rotation = Quaternion.LookRotation(movement.value.normalized);
        if (rotation.eulerAngles.magnitude > 0 && isActive)
        {
            player.rotation = Quaternion.Slerp(player.rotation,rotation,Time.smoothDeltaTime*turnSmoothTime);
        }
        controller.Move(transform.forward * anim.deltaPosition.magnitude * speed);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward*10000);
    }
}