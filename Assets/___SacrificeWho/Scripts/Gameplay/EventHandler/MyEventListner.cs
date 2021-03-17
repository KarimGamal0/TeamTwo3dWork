using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MyEventListner : MonoBehaviour
    {
   [SerializeField]  UnityEvent myevent;
   [SerializeField]  MyEventSO emptyPaper;
    private void OnEnable()
    {
        emptyPaper.RegisterEvent(this);
       // Debug.Log($"Listner registred{this}");
    }
    private void OnDisable()
    {
        emptyPaper.UnRegisterEvent(this);
    }
    public void OnEventRaise()
    {
        myevent.Invoke();
    }
}
