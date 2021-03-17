using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SwitchCharacter : MonoBehaviour
{
    
    [SerializeField] CinemachineVirtualCamera knightFollow;
    [SerializeField] GameObject knight;
    [SerializeField] CinemachineVirtualCamera archerFollow;
    [SerializeField] GameObject archer;
    [SerializeField] CinemachineVirtualCamera wizardFollow;
    [SerializeField] GameObject wizard;
    [SerializeField] Animator knightavatar;
    [SerializeField] Animator archeravatar;
    [SerializeField] Animator wizardavatar;
    [SerializeField] CharacterController knightcontroller;
    [SerializeField] CharacterController archercontroller;
    [SerializeField] CharacterController wizardcontroller;
    [SerializeField] Transform knightTransform;
    [SerializeField] Transform archerTransform;
    [SerializeField] Transform wizardTransform;
    [SerializeField] ThirdPersonController thirdperson;
    [SerializeField] Jump jumper;

    private void Update()
    {
        if (knight.activeInHierarchy)
        {
            knightFollow.m_Priority = 10;
            archerFollow.m_Priority = 0;
            wizardFollow.m_Priority = 0;
            archer.SetActive(true);
            wizard.SetActive(true);
            thirdperson.controller = knightcontroller;
            thirdperson.player = knightTransform;
            jumper.controller = knightcontroller;
            thirdperson.anim = knightavatar;
            wizardavatar.SetBool("isRunning", false);
            archeravatar.SetBool("isRunning", false);
        }
        if (archer.activeInHierarchy&&!knight.activeInHierarchy)
        {
            knightFollow.m_Priority = 0;
            archerFollow.m_Priority = 10;
            wizardFollow.m_Priority = 0;
            thirdperson.controller = archercontroller;
            thirdperson.player = archerTransform;
            jumper.controller = archercontroller;
            thirdperson.anim = archeravatar;
            wizardavatar.SetBool("isRunning", false);
            knightavatar.SetBool("isRunning", false);
        }
        if (wizard.activeInHierarchy&&!archer.activeInHierarchy && !knight.activeInHierarchy)
        {
            knightFollow.m_Priority = 0;
            archerFollow.m_Priority = 0;
            wizardFollow.m_Priority = 10;
            thirdperson.controller = wizardcontroller;
            thirdperson.player = wizardTransform;
            jumper.controller = wizardcontroller;
            thirdperson.anim = wizardavatar;
            archeravatar.SetBool("isRunning", false);
            knightavatar.SetBool("isRunning", false);
        }
    }
    public void Switch()
    {
      if(knight.activeInHierarchy&&archer.activeInHierarchy&&wizard.activeInHierarchy)
        {
            knight.SetActive(false);
        }
        else if (!knight.activeInHierarchy && archer.activeInHierarchy && wizard.activeInHierarchy)
        {
            archer.SetActive(false);
        }
        else if (!knight.activeInHierarchy && !archer.activeInHierarchy && wizard.activeInHierarchy)
        {
            wizard.SetActive(false);
            knight.SetActive(true);
            archer.SetActive(true);
        }
    }
}
