using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHandler : MonoBehaviour
{
    //add box collider trigger true .... 
     bool teleportState = true;
    [SerializeField] Vector3 teleportArea;



    private void OnCollisionEnter(Collision collision)
    {

        {

            var Charcter = collision.gameObject.GetComponent<CharacterController>();
            if (Charcter != null)
            {

                Debug.Log("Teleported");
                Charcter.transform.position = teleportArea;
            }
        }
    }
}