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
        if ((am.sounds.GetValue(0) as Sound).volume >0.0f)
        {
            (am.sounds.GetValue(0) as Sound).loop = false;
            (am.sounds.GetValue(0) as Sound).volume = 0.0f;
        }
        else
        {
            (am.sounds.GetValue(0) as Sound).loop = false;
            (am.sounds.GetValue(0) as Sound).volume = 0.0f;
        }
    }
}
