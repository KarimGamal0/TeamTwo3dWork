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
        if (collision.CompareTag("Player"))
        {
            if (obstacleState)
            {
                obstacleState = false;
                Debug.Log("killed by arrow");

               // FindObjectOfType<AudioManager>().playAudio("ArrowHit");
                arrowsAnimator.SetBool(IsOpen, true);
                killCharcterSO?.Raise();//place listner on your charcter and trigger death function...
            }
        }
    }




}
