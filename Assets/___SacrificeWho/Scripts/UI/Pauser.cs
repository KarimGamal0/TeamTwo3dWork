using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pauser : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject Gameui;
    [SerializeField] BoolSO paused;
    private void Start()
    {
        paused.state = false;
    }
    public void Pause()
    {
        Gameui.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        paused.state = true;
    }
}
