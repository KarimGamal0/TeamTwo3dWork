using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHandler : MonoBehaviour
{

    private static readonly int IsOpen = Animator.StringToHash("IsOpen");
    [SerializeField] Animator[] _Spikeanimator;


    [SerializeField] MyEventSO killKnightSO;
    [SerializeField] MyEventSO killArcherSO;
    [SerializeField] MyEventSO killWizardSO;


    bool obstacleState = true;
    BoxCollider spikeGroupCollider;
    AudioManager soundManager;



    private void Awake()
    {
        _Spikeanimator = GetComponentsInChildren<Animator>();


        spikeGroupCollider = GetComponent<BoxCollider>();

        spikeGroupCollider.isTrigger = true;

    }


    private void OnTriggerEnter(Collider collision)

    {
  

        if (obstacleState)
        {

            var Charcter = collision.gameObject.GetComponent<CharacterController>();
            if (Charcter != null)
            
                {


                obstacleState = false;
                 Debug.Log("killed by spike");

                FindObjectOfType<AudioManager>().playAudio("FallOnSpikes");


                foreach (var spike in _Spikeanimator)
                {
                    spike?.SetBool(IsOpen, true);

                }
                if (collision.CompareTag("Wizard"))
                {
                    killWizardSO?.Raise();
                }
                if (collision.CompareTag("Knight"))
                {
                    killKnightSO?.Raise();
                }
                if (collision.CompareTag("Archer"))
                {
                    killArcherSO?.Raise();
                }

                collision.GetComponent<MyEventListner>()?.OnEventRaise();


            }
        }


    }
}

 



