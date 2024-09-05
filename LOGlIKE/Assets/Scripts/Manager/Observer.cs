using System.Collections.Generic;
using UnityEngine.UIElements;

public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);

    void NotifyObserver();
}

public interface IObserver
{
    void UpdateObserver();
}