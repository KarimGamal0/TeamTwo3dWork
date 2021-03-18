using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pauser : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] BoolSO paused;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        paused.state = true;
    }
}
