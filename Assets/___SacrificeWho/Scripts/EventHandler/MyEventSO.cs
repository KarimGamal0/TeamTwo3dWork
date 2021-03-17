using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu]
public class MyEventSO : ScriptableObject
{
    List<MyEventListner> EventListners = new List<MyEventListner>();


    //void OnEnable ()
    //{
    //    for (int i = EventListners.Count - 1; i >= 0; i--)
    //    {
    //        EventListners.Remove(EventListners[i]);
    //    }
    //}
    public void RegisterEvent(MyEventListner listner)
    {
      //  Debug.Log("Before if");
      //  Debug.Log($"{EventListners.Count}");
        if (!EventListners.Contains(listner))
        {
       //     Debug.Log("new event add to our list");
            EventListners.Add(listner);
        }
    }
    public void UnRegisterEvent(MyEventListner listner)
    {
        if (EventListners.Contains(listner))
        {

            EventListners.Remove(listner);
        }
    }

    public void Raise()
    {
        for (int i = EventListners.Count - 1; i >= 0; i--)
        {
          //  Debug.Log("2-raise event called from SO");
            EventListners[i].OnEventRaise();
        }

    }
 
}
