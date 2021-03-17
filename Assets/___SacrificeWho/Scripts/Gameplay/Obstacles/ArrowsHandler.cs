using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsHandler : MonoBehaviour
{
    private static readonly int IsOpen = Animator.StringToHash("IsOpen");
    private Animator arrowsAnimator;


    [SerializeField] MyEventSO killCharcterSO;
    bool obstacleState = true;





    private void Awake()
    {
        arrowsAnimator = GetComponent<Animator>();

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

                arrowsAnimator.SetBool(IsOpen, true);
                //todo arrows sound
                killCharcterSO.Raise();
            }
        }
    }

}
