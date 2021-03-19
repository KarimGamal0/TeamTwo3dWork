using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
    AudioManager Am;
    SwitchCharacter Switcher;
    [SerializeField] BoolSO isDeadKnight;
    [SerializeField] BoolSO isDeadArcher;
    [SerializeField] BoolSO isDeadWizard;

    void Start()
    {
        Switcher = FindObjectOfType<SwitchCharacter>();
        Am = FindObjectOfType<AudioManager>();
    }

    public void somonedied()
    {
        Switcher.Switch();
    }
    public void Lose()
    {
        Debug.Log("Fail");
        Am.playAudio("Fail");
    }
    public void Win()
    {
        Debug.Log("won");
        Am.playAudio("Win");
    }
    // Update is called once per frame
    void Update()
    {
        if(isDeadArcher.state&& isDeadKnight.state&& isDeadWizard.state)
        {
            Lose();
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            Win();
        }
    }
}
