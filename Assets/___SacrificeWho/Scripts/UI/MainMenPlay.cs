
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenPlay : MonoBehaviour
{

    //   [SerializeField] Button back10Levels;
   
    public void LoadLevels_UI()
    {
         SceneManager.LoadScene($"LevelSelection");
    }

}
