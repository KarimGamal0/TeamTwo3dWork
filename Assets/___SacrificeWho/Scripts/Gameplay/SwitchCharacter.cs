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

    private void Update()
    {
        if (knight.activeInHierarchy)
        {
            knightFollow.m_Priority = 10;
            archerFollow.m_Priority = 0;
            wizardFollow.m_Priority = 0;  
            archer.SetActive(true);
            wizard.SetActive(true);
        }
        if (archer.activeInHierarchy&&!knight.activeInHierarchy)
        {
            knightFollow.m_Priority = 0;
            archerFollow.m_Priority = 10;
            wizardFollow.m_Priority = 0;
        }
        if (wizard.activeInHierarchy&&!archer.activeInHierarchy && !knight.activeInHierarchy)
        {
            knightFollow.m_Priority = 0;
            archerFollow.m_Priority = 0;
            wizardFollow.m_Priority = 10;
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
