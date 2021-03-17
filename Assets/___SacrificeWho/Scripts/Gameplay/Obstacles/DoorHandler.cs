using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    /*
     * Door model must have : 
     * animator Componenet //with animation set to it  and bool  IsOpen 
     * no need for listners ...for now ... later you can add listner on the door and SO on button 
     * then call SO.raise() from buttonhandler scritp ... 
     */
    private static readonly int IsOpen = Animator.StringToHash("IsOpen");
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();


    }

    public void Open()
    {
        _animator?.SetBool(IsOpen, true);
    }
    public void Close()
    {
        _animator?.SetBool(IsOpen, false);
    }

}
