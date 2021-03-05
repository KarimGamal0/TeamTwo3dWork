using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quiter : MonoBehaviour
{
    public void Quit()
    {
    SceneManager.LoadScene(1);
    }
}
