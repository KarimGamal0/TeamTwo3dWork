using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SwitchCharacter : MonoBehaviour
{
  
    [SerializeField] Transform[] targets;
    [SerializeField] GameObject[] characters;
    [SerializeField] CinemachineVirtualCamera PersonFollow;
   
    Transform oldTarget;
    GameObject oldCharacter;
    private void Awake()
    {
        oldTarget = targets[0];
        oldCharacter.transform.position = characters[0].transform.position;
    }
    public void Switch()
    {
        oldCharacter.transform.position = PersonFollow.Follow.position;
        oldTarget = PersonFollow.LookAt;
        for (int i = 0; i < characters.Length; i++)
        {
            if(characters[i].activeInHierarchy)
            {
            PersonFollow.Follow = characters[i].transform;
            PersonFollow.LookAt = targets[i];
                if(PersonFollow.Follow.position==oldCharacter.transform.position&&PersonFollow.LookAt==oldTarget&&i<2)
                {
                    PersonFollow.Follow = characters[i+1].transform;
                    PersonFollow.LookAt = targets[i+1];
                }
            break;
            }
        }

    }
}
