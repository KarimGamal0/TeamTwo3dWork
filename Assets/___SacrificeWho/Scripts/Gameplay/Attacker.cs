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
        anim = GetComponentInChildren<Animator>();
        Magic = GetComponentInChildren<ParticleSystem>();
        lineOne = GetComponent<LineRenderer>();
        if (Magic != null)
        {
            Magic.Stop();
        }
    }
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
    private void FixedUpdate()
    {
        Debug.DrawRay(muzzle.transform.position, muzzle.transform.forward * force);
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
        if (!isAttacking && /*Input.GetKeyDown(KeyCode.Mouse0) */isActiveController)
        {
            StartAttacking();
            anim.SetTrigger("Attack");

            RaycastHit hit;

            Ray ray = new Ray(muzzle.transform.position, muzzle.transform.forward);
            if (Physics.Raycast(ray, out hit, range))
            {
                RecivedPlayerController = hit.transform.GetComponent<CharacterController>();
                if (RecivedPlayerController)
                {
                    if (gameObject.transform.tag == "Knight")
                    {
                        AddImpact(muzzle.transform.forward, force);
                        FindObjectOfType<AudioManager>().playAudio("SwordHit");
                        hit.transform.gameObject.GetComponent<Death>().Dead();
                    }
                    if (gameObject.transform.tag == "Wizard")
                    {
                        Debug.Log(hit.transform.gameObject.name);
                        FindObjectOfType<AudioManager>().playAudio("Ice");
                        MagicAttack();
                        hit.transform.gameObject.GetComponent<CharacterController>().enabled = false;
                        hit.transform.gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
                        hit.transform.gameObject.GetComponentInChildren<BoxCollider>().enabled = true;
                        hit.transform.gameObject.GetComponent<Attacker>().enabled = false;
                        hit.transform.gameObject.GetComponent<Death>().Dead();
                    }
                    if (gameObject.transform.tag == "Archer")
                    {
                        AddImpact(muzzle.transform.forward, force);
                        FindObjectOfType<AudioManager>().playAudio("ArrowHit");
                        hit.transform.gameObject.GetComponent<Death>().Dead();
                    }
                }
            }

            FinishAttacking();
        }
    }
}
