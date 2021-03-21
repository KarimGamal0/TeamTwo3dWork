using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(Rigidbody))]
public class PlayersPhysics : MonoBehaviour
{
    public float pushPower = 2.0F;



    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.moveDirection.y < -0.3f)
            return;

        CharacterController controller= hit.gameObject.GetComponent<CharacterController>();
        if (controller)
        {
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            controller.Move(pushDir.normalized * pushPower);
        }
    }
}