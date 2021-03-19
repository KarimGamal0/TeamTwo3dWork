using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resumer : MonoBehaviour
{
    [SerializeField] GameObject gameui;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] BoolSO paused;
    public void Resume()
    {
        gameui.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        paused.state = false;
    }
}
