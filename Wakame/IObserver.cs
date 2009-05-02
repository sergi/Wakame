
using System;

namespace Wakame
{
    public interface IObserver
    {
        void Notify(object anObject);
    }
}
