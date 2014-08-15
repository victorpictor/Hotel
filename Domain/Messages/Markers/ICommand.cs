using System;

namespace Messages.Markers
{
    public interface ICommand
    {
        Guid Id { get; set; }
    }
}