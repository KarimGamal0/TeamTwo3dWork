using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quiter : MonoBehaviour
{
	[SerializeField] BoolSO paused;
    public void Quit()
    {
		Time.timeScale = 1.0f;
        paused.state = false;
    SceneManager.LoadScene(1);
    }
}
