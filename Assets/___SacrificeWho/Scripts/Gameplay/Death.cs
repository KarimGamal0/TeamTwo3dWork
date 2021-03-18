using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Death : MonoBehaviour
{
    Animator anim;
    public BoolSO isDead;

    [SerializeField] GameObject target;
    [SerializeField] CinemachineVirtualCamera cvcam; 
    private void Start()
    {
        isDead.state = false;
        anim = GetComponentInChildren<Animator>();
    }

    public void Dead()
    {
        isDead.state = true;
        anim.SetTrigger("Death");
        Destroy(target.gameObject);
        Destroy(cvcam.gameObject);

        //target.SetActive(false);
        //cvcam.enabled = false;

    }

}
