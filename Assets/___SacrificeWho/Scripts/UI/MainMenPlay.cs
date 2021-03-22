
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
    
   private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {

            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                // Quit the application
                Application.Quit();
            }
        }
    }
       

}
