using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] DoorHandler[] DoorsToOpen;
    [SerializeField] DoorHandler[] DoorsToClose;

    private static readonly int IsOpen = Animator.StringToHash("IsOpen");
    private Animator _ButtonAnimator;
    private BoxCollider CharcterDetector;

    public bool triggredNearCharcter = false;




    /*
     -Drop event listner on Button model  because khatab will call open from android button ... 
      Button model Must have 
      1- animator Componenet //with animation set to it  and bool  IsOpen 

    2-Box collider :
    dont forget to adjust the area of collider.. 
   Collider type is trigger to prevent colliosn with other objects ... 
    --------------------------------------------------------
    The collided or triggred object could have charcter controller to be able to activate the button 
    */

    private void Awake()
    {
        _ButtonAnimator = GetComponent<Animator>();
        CharcterDetector = GetComponent<BoxCollider>();
        CharcterDetector.isTrigger = true;
    }

    public void Open()
    {
        if (triggredNearCharcter==true)
        {
            _ButtonAnimator.SetBool(IsOpen, true);
           
            for (int i = 0; i < DoorsToOpen?.Length; i++)
            {
                DoorsToOpen[i]?.Open();
            }
            for (int i = 0; i < DoorsToClose?.Length; i++)
            {
                DoorsToClose[i]?.Close();
            }
        }
    }




    private void OnTriggerStay(Collider collision)
    {
        var  Charcter= collision.gameObject.GetComponent<CharacterController>();
        if (Charcter != null)
        {
            triggredNearCharcter = true;
        }
    }


    private void OnTriggerExit(Collider collision)
    {
        var Charcter = collision.gameObject.GetComponent<CharacterController>();
        if (Charcter!=null)
        {
            triggredNearCharcter = false;
        }
    }
 
}


/*
drop my event listner on the Button 
bind open function with the event from unity Inspector .
 */