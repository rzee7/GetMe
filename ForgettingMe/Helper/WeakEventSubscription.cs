using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgettingMe
{
    public class WeakEventSubscription<TSource, TEventArgs> : IDisposable
        where TSource : class
        where TEventArgs : EventArgs
    {

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //RemoveEventHandler();
            }
        }
    }
}
