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
    [SerializeField] BoolSO knightdeath;
    [SerializeField] BoolSO archerdeath;
    [SerializeField] BoolSO wizarddeath;
    [SerializeField] Attacker knightattacker;
    [SerializeField] Attacker archerattacker;
    [SerializeField] Attacker wizardattacker;
    [SerializeField] Transform knightTransform;
    [SerializeField] Transform archerTransform;
    [SerializeField] Transform wizardTransform;
    [SerializeField] ThirdPersonController thirdperson;
    [SerializeField] JoystickThirdPersonController JSthirdperson;
    [SerializeField] Jump jumper;

    private void Update()
    {
        AutoSwitch();
    }
    public void Switch()
    {
        if (!knightdeath.state && !archerdeath.state && !wizarddeath.state)
        {
            if (knight.activeInHierarchy)
            {
                knightFollow.m_Priority = 10;
                archerFollow.m_Priority = 0;
                wizardFollow.m_Priority = 0;
                knight.SetActive(false);
                archer.SetActive(true);

                thirdperson.controller = knightcontroller;
                thirdperson.player = knightTransform;
                JSthirdperson.controller = knightcontroller;
                JSthirdperson.player = knightTransform;

                jumper.controller = knightcontroller;
                thirdperson.anim = knightavatar;
                knightattacker.isActiveController = true;
                archerattacker.isActiveController = false;
                wizardattacker.isActiveController = false;
                wizardavatar.SetBool("isRunning", false);
                archeravatar.SetBool("isRunning", false);
                return;
            }
            else if (archer.activeInHierarchy)
            {
                knightFollow.m_Priority = 0;
                archerFollow.m_Priority = 10;
                wizardFollow.m_Priority = 0;
                archer.SetActive(false);
                wizard.SetActive(true);
                thirdperson.controller = archercontroller;
                thirdperson.player = archerTransform;
                JSthirdperson.controller = archercontroller;
                JSthirdperson.player = archerTransform;

                jumper.controller = archercontroller;
                thirdperson.anim = archeravatar;
                knightattacker.isActiveController = false;
                archerattacker.isActiveController = true;
                wizardattacker.isActiveController = false;
                wizardavatar.SetBool("isRunning", false);
                knightavatar.SetBool("isRunning", false);
                return;
            }
            else if (wizard.activeInHierarchy)
            {
                knightFollow.m_Priority = 0;
                archerFollow.m_Priority = 0;
                wizardFollow.m_Priority = 10;
                knight.SetActive(true);
                wizard.SetActive(false);
                thirdperson.controller = wizardcontroller;
                thirdperson.player = wizardTransform;
                JSthirdperson.controller = wizardcontroller;
                JSthirdperson.player = wizardTransform;
                jumper.controller = wizardcontroller;
                thirdperson.anim = wizardavatar;
                knightattacker.isActiveController = false;
                archerattacker.isActiveController = false;
                wizardattacker.isActiveController = true;
                archeravatar.SetBool("isRunning", false);
                knightavatar.SetBool("isRunning", false);
                return;
            }
        }

        else if ((!knightdeath.state && !archerdeath.state && wizarddeath.state))
        {
            if (knight.activeInHierarchy)
            {
                knightFollow.m_Priority = 10;
                archerFollow.m_Priority = 0;
                knight.SetActive(false);
                archer.SetActive(true);

                thirdperson.controller = knightcontroller;
                thirdperson.player = knightTransform;
                JSthirdperson.controller = knightcontroller;
                JSthirdperson.player = knightTransform;

                jumper.controller = knightcontroller;
                thirdperson.anim = knightavatar;
                knightattacker.isActiveController = true;
                archerattacker.isActiveController = false;
                archeravatar.SetBool("isRunning", false);
                return;
            }
            else if (archer.activeInHierarchy)
            {
                knightFollow.m_Priority = 0;
                archerFollow.m_Priority = 10;
                archer.SetActive(false);
                knight.SetActive(true);
                thirdperson.controller = archercontroller;
                thirdperson.player = archerTransform;
                JSthirdperson.controller = archercontroller;
                JSthirdperson.player = archerTransform;

                jumper.controller = archercontroller;
                thirdperson.anim = archeravatar;
                knightattacker.isActiveController = false;
                archerattacker.isActiveController = true;
                knightavatar.SetBool("isRunning", false);
                return;
            }
        }
        else if ((!knightdeath.state && archerdeath.state && !wizarddeath.state))
        {
            if (knight.activeInHierarchy)
            {
                knightFollow.m_Priority = 10;
                wizardFollow.m_Priority = 0;
                knight.SetActive(false);
                wizard.SetActive(true);

                thirdperson.controller = knightcontroller;
                thirdperson.player = knightTransform;
                JSthirdperson.controller = knightcontroller;
                JSthirdperson.player = knightTransform;

                jumper.controller = knightcontroller;
                thirdperson.anim = knightavatar;
                knightattacker.isActiveController = true;
                wizardattacker.isActiveController = false;
                wizardavatar.SetBool("isRunning", false);
                return;
            }
            else if (wizard.activeInHierarchy)
            {
                knightFollow.m_Priority = 0;
                wizardFollow.m_Priority = 10;
                knight.SetActive(true);
                wizard.SetActive(false);
                thirdperson.controller = wizardcontroller;
                thirdperson.player = wizardTransform;
                JSthirdperson.controller = wizardcontroller;
                JSthirdperson.player = wizardTransform;
                jumper.controller = wizardcontroller;
                thirdperson.anim = wizardavatar;
                knightattacker.isActiveController = false;
                wizardattacker.isActiveController = true;
                knightavatar.SetBool("isRunning", false);
                return;
            }
        }
        else if (knightdeath.state && !archerdeath.state && !wizarddeath.state)
        {
            if (archer.activeInHierarchy)
            {
                archerFollow.m_Priority = 10;
                wizardFollow.m_Priority = 0;
                archer.SetActive(false);
                wizard.SetActive(true);
                thirdperson.controller = archercontroller;
                thirdperson.player = archerTransform;
                JSthirdperson.controller = archercontroller;
                JSthirdperson.player = archerTransform;

                jumper.controller = archercontroller;
                thirdperson.anim = archeravatar;
                archerattacker.isActiveController = true;
                wizardattacker.isActiveController = false;
                wizardavatar.SetBool("isRunning", false);
                return;
            }
            else if (wizard.activeInHierarchy)
            {
                archerFollow.m_Priority = 0;
                wizardFollow.m_Priority = 10;
                archer.SetActive(true);
                wizard.SetActive(false);
                thirdperson.controller = wizardcontroller;
                thirdperson.player = wizardTransform;
                JSthirdperson.controller = wizardcontroller;
                JSthirdperson.player = wizardTransform;
                jumper.controller = wizardcontroller;
                thirdperson.anim = wizardavatar;
                archerattacker.isActiveController = false;
                wizardattacker.isActiveController = true;
                archeravatar.SetBool("isRunning", false);
                return;
            }
        }

        else if ((!knightdeath.state && archerdeath.state && wizarddeath.state))
        {
            if (knight.activeInHierarchy)
            {
                knightFollow.m_Priority = 10;
                knight.SetActive(false);

                thirdperson.controller = knightcontroller;
                thirdperson.player = knightTransform;
                JSthirdperson.controller = knightcontroller;
                JSthirdperson.player = knightTransform;

                jumper.controller = knightcontroller;
                thirdperson.anim = knightavatar;
                knightattacker.isActiveController = true;
                return;
            }
        }
        else if ((knightdeath.state && archerdeath.state && !wizarddeath.state))
        {
            if (wizard.activeInHierarchy)
            {
                wizardFollow.m_Priority = 10;
                wizard.SetActive(false);
                thirdperson.controller = wizardcontroller;
                thirdperson.player = wizardTransform;
                JSthirdperson.controller = wizardcontroller;
                JSthirdperson.player = wizardTransform;
                jumper.controller = wizardcontroller;
                thirdperson.anim = wizardavatar;

                wizardattacker.isActiveController = true;
                return;
            }
        }
        else if (knightdeath.state && !archerdeath.state && wizarddeath.state)
        {
            if (archer.activeInHierarchy)
            {

                archerFollow.m_Priority = 10;

                archer.SetActive(false);
                thirdperson.controller = archercontroller;
                thirdperson.player = archerTransform;
                JSthirdperson.controller = archercontroller;
                JSthirdperson.player = archerTransform;
                jumper.controller = archercontroller;
                thirdperson.anim = archeravatar;
                archerattacker.isActiveController = true;
                return;
            }
        }

    }

    public void AutoSwitch()
    {
        if ((!knightdeath.state && knight.activeInHierarchy) || (archerdeath.state && !archer.activeInHierarchy && wizarddeath.state && !wizard.activeInHierarchy))
        {

            knightFollow.m_Priority = 10;
            archerFollow.m_Priority = 0;
            wizardFollow.m_Priority = 0;
            knight.SetActive(true);
            archer.SetActive(false);
            wizard.SetActive(false);

            thirdperson.controller = knightcontroller;
            thirdperson.player = knightTransform;
            JSthirdperson.controller = knightcontroller;
            JSthirdperson.player = knightTransform;

            jumper.controller = knightcontroller;
            thirdperson.anim = knightavatar;
            knightattacker.isActiveController = true;
            archerattacker.isActiveController = false;
            wizardattacker.isActiveController = false;
            wizardavatar.SetBool("isRunning", false);
            archeravatar.SetBool("isRunning", false);
        }
        if ((!archerdeath.state && archer.activeInHierarchy) || (knightdeath.state && !knight.activeInHierarchy && wizarddeath.state && !wizard.activeInHierarchy))
        {
            knightFollow.m_Priority = 0;
            archerFollow.m_Priority = 10;
            wizardFollow.m_Priority = 0;
            knight.SetActive(false);
            archer.SetActive(true);
            wizard.SetActive(false);
            thirdperson.controller = archercontroller;
            thirdperson.player = archerTransform;
            JSthirdperson.controller = archercontroller;
            JSthirdperson.player = archerTransform;

            jumper.controller = archercontroller;
            thirdperson.anim = archeravatar;
            knightattacker.isActiveController = false;
            archerattacker.isActiveController = true;
            wizardattacker.isActiveController = false;
            wizardavatar.SetBool("isRunning", false);
            knightavatar.SetBool("isRunning", false);
        }
        if ((!wizarddeath.state && wizard.activeInHierarchy) || (archerdeath.state && !archer.activeInHierarchy && knightdeath.state && !knight.activeInHierarchy))
        {
            knightFollow.m_Priority = 0;
            archerFollow.m_Priority = 0;
            wizardFollow.m_Priority = 10;
            knight.SetActive(false);
            archer.SetActive(false);
            wizard.SetActive(true);
            thirdperson.controller = wizardcontroller;
            thirdperson.player = wizardTransform;
            JSthirdperson.controller = wizardcontroller;
            JSthirdperson.player = wizardTransform;
            jumper.controller = wizardcontroller;
            thirdperson.anim = wizardavatar;
            knightattacker.isActiveController = false;
            archerattacker.isActiveController = false;
            wizardattacker.isActiveController = true;
            archeravatar.SetBool("isRunning", false);
            knightavatar.SetBool("isRunning", false);
        }
    }
}