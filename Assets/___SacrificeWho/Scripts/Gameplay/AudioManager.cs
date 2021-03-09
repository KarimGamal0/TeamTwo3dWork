using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] BoolSO walking;
    [SerializeField] BoolSO falling;
    [SerializeField] BoolSO won;
    [SerializeField] BoolSO lost;
    [SerializeField] BoolSO pressed;
    [SerializeField] BoolSO swordhit;
    [SerializeField] BoolSO arrowhit;
    [SerializeField] BoolSO icehit;
    [SerializeField] BoolSO jumping;
    [SerializeField] BoolSO Switch;
    [SerializeField] AudioSource audioSource;
    [SerializeField] List<AudioClip> clips = new List<AudioClip>();

    void Start()
    {
        DontDestroyOnLoad(this);
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(walking.state==true)
        {
            audioSource.volume = 0.2f;
            audioSource.PlayOneShot(clips[2]);
        }

    }
}
