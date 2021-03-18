using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHandler : MonoBehaviour
{

    private static readonly int IsOpen = Animator.StringToHash("IsOpen");
    private Animator[] _Spikeanimator;


    [SerializeField] MyEventSO killCharcterSO;
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
            obstacleState = false; //activate one time 

            var Charcter = collision.gameObject.GetComponent<CharacterController>();
            if (Charcter != null)
            {
                Debug.Log("killed by spike");

                FindObjectOfType<AudioManager>().playAudio("FallOnSpikes");



                foreach (var spike in _Spikeanimator)
                {
                    spike.SetBool(IsOpen, true);
                }
                killCharcterSO.Raise();

            }
        }
    }


}

 



