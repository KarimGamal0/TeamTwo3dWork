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

    [SerializeField]
    GameObject muzzle;

    [SerializeField]
    float range = 10.0f;

    [SerializeField]
    float force = 5.0f;

    [SerializeField]
    float mass = 3.0f;
    Animator anim;

    CharacterController RecivedPlayerController;
    LineRenderer lineOne;

    Vector3 impact;
    RaycastHit rayHit;
    void Start()
    {
        //GetComponentInChildren<Animator>().GetComponentInChildren<AnimationClip>().AddEvent(Event);
        anim = GetComponentInChildren<Animator>();
        Magic = GetComponentInChildren<ParticleSystem>();
        lineOne = GetComponent<LineRenderer>();
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


    public void MagicAttack()
    {
        if (attacktype == AttackType.wizard && isActiveController)
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


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Slash();
        }
    }
    public void Slash()
    {
        RaycastHit hit;

        Ray ray = new Ray(muzzle.transform.position, muzzle.transform.forward);
        if (Physics.Raycast(ray, out hit, range))
        {

            if (gameObject.transform.tag == "Knight")
            {
                ImpactReciever impact = hit.transform.gameObject.GetComponent<ImpactReciever>();
                if (impact)
                {
                    impact.AddImpact(ray.direction, force);
                }
            }
            if (gameObject.transform.tag == "Wizard")
            {
                hit.transform.gameObject.GetComponent<CharacterController>().enabled = false;
                hit.transform.gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
                hit.transform.gameObject.GetComponentInChildren<BoxCollider>().enabled = true;
                hit.transform.gameObject.GetComponent<Attacker>().enabled = false;
                hit.transform.gameObject.GetComponent<Death>().Dead();
            }
            if (gameObject.transform.tag == "Archer")
            {

            }
        }



    }


    private void FixedUpdate()
    {

        Debug.DrawRay(muzzle.transform.position, muzzle.transform.forward * force);

        lineOne.SetPosition(0, muzzle.transform.position);
        lineOne.SetPosition(1, muzzle.transform.forward * 1000);

        if (RecivedPlayerController)
        {


            if (impact.magnitude > 0.2F) RecivedPlayerController.Move(impact * Time.deltaTime);
            // consumes the impact energy each cycle:
            impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.fixedDeltaTime);
        }

    }

    public void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * force / mass;
    }


    public void Attack()
    {
        Ray ray = new Ray(muzzle.transform.position, muzzle.transform.forward);

        if (Physics.Raycast(muzzle.transform.position, muzzle.transform.forward, out rayHit))
        {
            RecivedPlayerController = rayHit.transform.GetComponent<CharacterController>();
            if (RecivedPlayerController)
            {
                AddImpact(muzzle.transform.forward, force);

            }
        }

        if (!isAttacking && /*Input.GetKeyDown(KeyCode.Mouse0) */isActiveController)
        {
            StartAttacking();
            anim.SetTrigger("Attack");
            Ray ray1 = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray1, out hit, 5.0f))
            {
                if (hit.transform.tag == "Archer" || hit.transform.tag == "wizard")
                {
                    hit.transform.position += transform.forward * 5.0f;
                }
            }
            if (attacktype == AttackType.wizard)
            {
                MagicAttack();
            }
            FinishAttacking();
        }
    }
}
