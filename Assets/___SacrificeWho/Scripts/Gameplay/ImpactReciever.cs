using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactReciever : MonoBehaviour
{
    float mass = 3.0f;
    Vector3 imapct = Vector3.zero;
    CharacterController character;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (imapct.magnitude > 0.2f)
        {
            character.Move(imapct * Time.deltaTime);
            imapct = Vector3.Lerp(imapct, Vector3.zero, 5 * Time.deltaTime);
        }
    }
    public void AddImpact(Vector3 dir, float force)
    {

        dir.Normalize();

        if (dir.y < 0)
        {
            dir.y = -dir.y;
        }

        imapct += dir.normalized * force / mass;
    }
}
