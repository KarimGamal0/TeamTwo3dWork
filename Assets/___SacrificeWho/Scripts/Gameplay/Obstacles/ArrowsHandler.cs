using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsHandler : MonoBehaviour
{
    private static readonly int IsOpen = Animator.StringToHash("IsOpen");
    private Animator arrowsAnimator;
    private BoxCollider CollideCHecker;


    [SerializeField] MyEventSO killCharcterSO;
    bool obstacleState = true;





    private void Awake()
    {
        arrowsAnimator = GetComponent<Animator>();
        CollideCHecker = GetComponent<BoxCollider>();
        CollideCHecker.isTrigger = true;
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (obstacleState)
        {
            obstacleState = false; //activate one time 

            var Charcter = collision.gameObject.GetComponent<CharacterController>();
            if (Charcter != null)
            {
                Debug.Log("killed by arrow");

                FindObjectOfType<AudioManager>().playAudio("ArrowHit");
                arrowsAnimator.SetBool(IsOpen, true);
                //todo arrows sound
                killCharcterSO.Raise();//place listner on your charcter and trigger death function...
            }
        }
    }




}
