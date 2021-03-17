using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHandler : MonoBehaviour
{

    private static readonly int IsOpen = Animator.StringToHash("IsOpen");
    private Animator _Spikeanimator;


    [SerializeField] MyEventSO killCharcterSO;
    bool obstacleState = true; 





    private void Awake()
    {
        _Spikeanimator = GetComponent<Animator>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (obstacleState)
        {
            obstacleState = false; //activate one time 

            var Charcter = collision.gameObject.GetComponent<CharacterController>();
            if (Charcter != null)
            {
                Debug.Log("killed by spike");

                _Spikeanimator.SetBool(IsOpen, true);

                killCharcterSO.Raise();
            }
        }
    }


}

 



