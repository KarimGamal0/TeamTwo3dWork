using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    //[SerializeField] DoorHandler[] DoorsToOpen;   zombie code
    //[SerializeField] DoorHandler[] DoorsToClose;  zombie code

    private static readonly int IsOpen = Animator.StringToHash("IsOpen");
    private Animator _ButtonAnimator;
    BoxCollider boxtrigger;
    public bool CollideOneTimeOnly = true;
    public MyEventSO open_Portal_SO;   



    private void Awake()
    {
        _ButtonAnimator = GetComponent<Animator>();
        boxtrigger = GetComponent<BoxCollider>();
        boxtrigger.isTrigger = true; 

    }





    
  
    private void OnTriggerEnter(Collider collision)
    {
       
        if (collision.CompareTag("Player"))
        {
            if (CollideOneTimeOnly)
            {
                CollideOneTimeOnly = false;

                Debug.Log("collided with key portal");
                _ButtonAnimator.SetBool(IsOpen, true);
                open_Portal_SO?.Raise();

            }

   
        }
  
    }



}


/*
drop my event listner on the Button 
bind open function with the event from unity Inspector .
 */

//zomie code... 
//for (int i = 0; i < DoorsToOpen?.Length; i++)
//{
//    DoorsToOpen[i]?.Open();
//}
//for (int i = 0; i < DoorsToClose?.Length; i++)
//{
//    DoorsToClose[i]?.Close();
//}