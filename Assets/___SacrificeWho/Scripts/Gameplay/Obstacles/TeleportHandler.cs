using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHandler : MonoBehaviour
{
    //add box collider trigger true .... 
     bool teleportState = true;
    [SerializeField] Transform teleportArea;

    BoxCollider CharcterDetector;
    private void Awake()
    {
        CharcterDetector = GetComponent<BoxCollider>();
        CharcterDetector.isTrigger = true;

    }

    private void OnTriggerEnter(Collider collision)
    {

        {

            var Charcter = collision.gameObject.GetComponent<CharacterController>();
            if (Charcter != null)
            {

                Debug.Log("Teleported");
                Charcter.transform.position = teleportArea.position;
            }
        }
    }
}