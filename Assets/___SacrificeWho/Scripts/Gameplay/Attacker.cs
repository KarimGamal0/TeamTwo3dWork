using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    None,
    wizard,
    archer,
    knight
}
public class Attacker : MonoBehaviour
{
    public AttackType attacktype = AttackType.None;
    public bool isActiveController = false;
    bool isAttacking;

    [SerializeField]
    ParticleSystem Magic;

    Animator anim;
    void Start()
    {
        //GetComponentInChildren<Animator>().GetComponentInChildren<AnimationClip>().AddEvent(Event);
        anim = GetComponentInChildren<Animator>();
        Magic = GetComponentInChildren<ParticleSystem>();
        if (Magic != null)
        {
            Magic.Stop();
        }
    }

    //private void Update()
    //{
    //    Attack();
    //}

    IEnumerator StopMagic()
    {
        yield return new WaitForSeconds(1.0f);
        Magic.Stop();
    }

    public void Attack()
    {
        if (!isAttacking && /*Input.GetKeyDown(KeyCode.Mouse0) */isActiveController)
        {
            StartAttacking();
            anim.SetTrigger("Attack");
            Ray ray=new Ray(transform.position,transform.forward);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit,5.0f))
            {
                if(hit.transform.tag=="Archer"||hit.transform.tag=="wizard")
                {
                    hit.transform.position += transform.forward * 5.0f;
                }
            }
            if(attacktype==AttackType.wizard)
            {
                MagicAttack();
            }
            FinishAttacking();
        }
    }

    public void MagicAttack()
    {
        if (attacktype == AttackType.wizard&& isActiveController)
        {
            anim.SetTrigger("Attack");
            Magic.Play();
            StartCoroutine(StopMagic());
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
