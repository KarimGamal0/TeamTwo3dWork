using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    bool playerHitFlag;

    CharacterController player;


    private void Start()
    {
        var boxCollider= GetComponent<BoxCollider>();
        boxCollider.isTrigger = true; 
    }

    private void OnTriggerEnter(Collider hit)
    {
         player = hit.GetComponent<CharacterController>();
  

        if (playerHitFlag)
        {

            playerHitFlag = false;
            player.Move(hit.transform.position);
        }


        if (player)
        {
            playerHitFlag = true;
        }





    }



}
