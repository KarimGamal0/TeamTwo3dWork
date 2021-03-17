using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    bool isAttacking;

    Animator anim;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (!isAttacking && Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartAttacking();
            anim.SetTrigger("MeleeAttack");
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
