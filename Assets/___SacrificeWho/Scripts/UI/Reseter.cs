using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reseter : MonoBehaviour
{
[SerializeField] BoolSO paused;

    public void Reset()
    {
		Time.timeScale = 1.0f;
        paused.state = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
