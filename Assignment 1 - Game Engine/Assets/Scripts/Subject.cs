using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ObserverPattern
{
    public class Subject
    {
        List<Observer> observers = new List<Observer>(); // stores all observers

        public void Notify()
        {
            for (int i = 0; i < observers.Count; i++)
            {
                observers[i].OnNotify();    //notifies
            }
        }

        public void AddObserver(Observer observer)
        {
            observers.Add(observer);
        }
    }
}