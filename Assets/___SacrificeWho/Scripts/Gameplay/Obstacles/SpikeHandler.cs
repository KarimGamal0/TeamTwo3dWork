using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHandler : MonoBehaviour
{

    private static readonly int IsOpen = Animator.StringToHash("IsOpen");
    [SerializeField] Animator _Spikeanimator;


    [SerializeField] MyEventSO killCharcterSO;
    bool obstacleState = true;
    BoxCollider spikeGroupCollider;
    AudioManager soundManager;



    private void Awake()
    {
        _Spikeanimator = GetComponentInChildren<Animator>();
        if (_Spikeanimator)
        {
            Debug.Log("foundAnimtaor");

        }

        else
        {
            Debug.Log("didnot foundAnimtaor");

        }

        spikeGroupCollider = GetComponent<BoxCollider>();

        spikeGroupCollider.isTrigger = true;

    }


    private void OnTriggerEnter(Collider collision)

    {
  

        if (obstacleState)
        {

            if (collision.CompareTag("Player"))
            {


                obstacleState = false;
                 Debug.Log("killed by spike");

                    // FindObjectOfType<AudioManager>().playAudio("FallOnSpikes");

                    _Spikeanimator.SetBool(IsOpen, true);
                    
                    killCharcterSO?.Raise();

                
            }
        }


    }
}

 



