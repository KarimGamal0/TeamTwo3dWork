using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    //   [SerializeField] Button back10Levels;
    [SerializeField] Canvas LevelS_UIcanvas;
    [SerializeField] GameObject ButtonsHolder_1_10;
    [SerializeField] GameObject ButtonsHolder_11_20;
    [SerializeField] Button navBack;
    [SerializeField] Button navForward;
    [SerializeField] Button PlayButtons;

    int shiftPage =1;
    int maxPages = 2;
    int minPages = 1;


    // Start is called before the first frame update
    void Start()
    {
        navBack.gameObject.SetActive(false);

    }

    // Update is called once per frame


    public void ShiftNext10Levels()
    {
        if (shiftPage < maxPages)
        {
            shiftPage++;

            if (shiftPage == 2)
            {
                navBack.gameObject.SetActive(true);

                ButtonsHolder_1_10.SetActive(false);
                ButtonsHolder_11_20.SetActive(true);


            }

            if (shiftPage == maxPages)
            {
                navForward.gameObject.SetActive(false);
            }


        }

    }

    public void BackNext10Levels()
    {
        navForward.gameObject.SetActive(true);

        if (shiftPage > minPages)
        {
            shiftPage--;

            ButtonsHolder_1_10.SetActive(true);
            ButtonsHolder_11_20.SetActive(false);
        }


        if (shiftPage == minPages)
        {
            navBack.gameObject.SetActive(false);

        }

        if (shiftPage == maxPages-1)
        {
            navForward.gameObject.SetActive(true);
        }

    }


    public  void LoadLevel(string levelNum)
    {
        Debug.Log($"Loading .... Level{levelNum}");
        SceneManager.LoadScene($"Level{levelNum}");

    }




    public void OnPressPlayBtn()
    {
        PlayButtons.enabled = false;
        Debug.Log("AB");

    }


    public void LoadMainMenu_UI()
    {
        SceneManager.LoadScene($"MainMenu");
    }


}



//void GetclickedBtn_NUM()
//{
//    var go = EventSystem.current.currentSelectedGameObject;
//    if (go != null)
//    {
//        Debug.Log("Clicked on : " + go.name);
// //       LoadLevel(go.name);
//    }
//    else
//        Debug.Log("currentSelectedGameObject is null");
//}