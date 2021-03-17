using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMToggler : MonoBehaviour
{
    AudioManager am;
    private void Start()
    {
        am = FindObjectOfType<AudioManager>();
    }
    //TODO:BGM audio toggle
    public void ToggleAudio()
    {
       if(am.sounds[0].volume>0.0f)
        {
            am.sounds[0].volume = 0.0f;
            am.GetComponent<AudioSource>().clip = null;
            am.playAudio("theme");

        }
       else
        {
            am.sounds[0].volume = 0.5f;
            am.GetComponent<AudioSource>().clip = am.sounds[0].clip;
            am.playAudio("theme");
        }
    }
}
