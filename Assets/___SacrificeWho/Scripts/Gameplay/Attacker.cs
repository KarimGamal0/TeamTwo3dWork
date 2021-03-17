using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public bool isActiveController = false;
    bool isAttacking;

    Animator anim;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void Attack()
    {
        if (!isAttacking && isActiveController)
        {
            StartAttacking();
            anim.SetTrigger("Attack");
            FinishAttacking();
        }
    }

    void StartAttacking()
    {
        isAttacking = true;
    }

    void FinishAttacking()
    {
        isAttacking = false;
    }
}
