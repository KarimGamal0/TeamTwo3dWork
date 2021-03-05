using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resumer : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] BoolSO paused;
    public void Pause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 0.0f;
        paused.state = false;
    }
}
