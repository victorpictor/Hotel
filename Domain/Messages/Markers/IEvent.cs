using System;

namespace Messages.Markers
{
    public interface IEvent
    {
        Guid Id { get; set; }
    }
}