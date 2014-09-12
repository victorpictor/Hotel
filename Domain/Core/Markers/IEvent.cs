using System;

namespace Core.Markers
{
    public interface IEvent
    {
        Guid Id { get; set; }
    }
}