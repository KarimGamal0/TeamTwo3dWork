using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXToggler : MonoBehaviour
{
    //TODO:SFX audio toggle
    AudioListener al;
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
        }
        else
        {
            al.enabled = true;
        }
    }
}
