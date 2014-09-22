using System;
using Core.Markers;

namespace ProcessManagement.Processes.State
{
    public abstract class IHave<T>
    {
        protected T State { get; set; }

        protected abstract void Receive(Action<IEvent> action, IEvent ev);

    }
}