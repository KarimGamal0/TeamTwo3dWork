using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsHandler : MonoBehaviour
{
    private static readonly int IsOpen = Animator.StringToHash("IsOpen");
    private Animator arrowsAnimator;
    private BoxCollider CollideCHecker;


    [SerializeField] MyEventSO killKnightSO;
    [SerializeField] MyEventSO killArcherSO;
    [SerializeField] MyEventSO killWizardSO;

    bool obstacleState = true;





    private void Awake()
    {
        arrowsAnimator = GetComponent<Animator>();
        CollideCHecker = GetComponent<BoxCollider>();
        CollideCHecker.isTrigger = true;
    }


    private void OnTriggerEnter(Collider collision)
    {
        var Charcter = collision.gameObject.GetComponent<CharacterController>();
        if (Charcter != null)
        {
            if (obstacleState)
            {
                obstacleState = false;
                Debug.Log("killed by arrow");

                ////CollideCHecker.isTrigger = false;

                FindObjectOfType<AudioManager>().playAudio("ArrowHit");
                arrowsAnimator.SetBool(IsOpen, true);

                // collision.GetComponent<MyEventListner>()?.OnEventRaise();
                if (collision.CompareTag("Wizard"))
                {
                    killWizardSO.Raise();
                }
                if (collision.CompareTag("Knight"))
                {
                    Debug.Log("kingt");

                    killKnightSO.Raise();
                }
                if (collision.CompareTag("Archer"))
                {
                    killArcherSO.Raise();
                }



                //  killKnightSO?.Raise();//place listner on your charcter and trigger death function...

            }
        }
    }




}
