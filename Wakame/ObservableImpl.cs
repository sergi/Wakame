
using System;

namespace Wakame
{
    public class ObservableImpl:IObservable
    {
        protected Hashtable _observerContainer=new Hashtable();
        
        //add the observer
        public void Register(IObserver anObserver){
          _observerContainer.Add(anObserver,anObserver); 
        }
          
        //remove the observer
        public void UnRegister(IObserver anObserver){
          _observerContainer.Remove(anObserver); 
        }
        
        //common method to notify all the observers
        public void NotifyObservers(object anObject) 
        {
          //enumeration the observers and invoke their notify method
          foreach(IObserver anObserver in _observerContainer.Keys)
             anObserver.Notify(anObject);
        }
    }
}
