using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {

            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                // Quit the application
                SceneManager.LoadScene($"LevelSelection");
            }
        }
    }
    public void Pause()
    {
        Gameui.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        paused.state = true;
    }
}
