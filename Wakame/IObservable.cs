using System;

namespace Wakame
{
    public interface IObservable
    {
        void Register(IObserver anObserver);
        void UnRegister(IObserver anObserver);
        void NotifyObservers(object anObject);
    }
}
