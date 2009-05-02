using System;
using System.Collections;
using Gtk;

namespace Gui
{
    public abstract class ObservableTree : Gtk.TreeView, Wakame.IObservable
    {
        protected Hashtable _observerContainer = new Hashtable();

        public void Register(Wakame.IObserver anObserver)
        {
          _observerContainer.Add(anObserver,anObserver); 
        }

        public void UnRegister(Wakame.IObserver anObserver)
        {
          _observerContainer.Remove(anObserver); 
        }

        public void NotifyObservers(object anObject) 
        {
          foreach(Wakame.IObserver anObserver in _observerContainer.Keys)
             anObserver.Notify(anObject);
        }

        #region "Utility functions"

        protected TreeViewColumn addColumn(string name)
        {
            CellRendererText Cell = new Gtk.CellRendererText();
            TreeViewColumn Column = new Gtk.TreeViewColumn();

            Column.Title = name;
            Column.PackStart (Cell, true);
            Column.AddAttribute(Cell, "text", 0);

            return Column;
        }
        
        #endregion
    }
}
