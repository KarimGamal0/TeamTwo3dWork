using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXToggler : MonoBehaviour
{
    //TODO:SFX audio toggle
    AudioListener al;
    [SerializeField]Sprite on;
    [SerializeField]Sprite off;
    [SerializeField]Button button;

    private void Start()
    {
        al = FindObjectOfType<AudioListener>();
    }
    //TODO:BGM audio toggle
    public void ToggleAudio()
    {
        if (al.enabled)
        {
            al.enabled = false;
            button.image.sprite = off;
        }
        else
        {
            al.enabled = true;
            button.image.sprite = on;
        }
    }
}
