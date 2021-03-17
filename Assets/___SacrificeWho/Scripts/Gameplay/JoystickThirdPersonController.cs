using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickThirdPersonController : MonoBehaviour
{
    [SerializeField]public Transform player;
    [SerializeField] public CharacterController controller;
    public  Animator anim;

    [SerializeField] float speed = 6.0f;
    [SerializeField] float turnSmoothTime = 0.1f;
    float turnSmoothVelcocity;


    [SerializeField] Vector3SO movement;
    // Update is called once per frame
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        Move();
    }

    void Move()
    {

        Vector3 direction = new Vector3(movement.value.x, 0.0f, movement.value.z).normalized;
      
        if (direction.magnitude >= 0.1f)
        {
            anim.SetBool("isRunning", true);
            //get the angle to rotate the character
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            //smooth rotation of the character
            float angle = Mathf.SmoothDampAngle(player.eulerAngles.y, targetAngle, ref turnSmoothVelcocity, turnSmoothTime);

            //rotate target with the direction
            player.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

            //switch the direction of the player with coordiates of the camera position
            Vector3 movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(movDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
