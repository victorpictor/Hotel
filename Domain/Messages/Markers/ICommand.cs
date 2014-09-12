using System;

namespace Core.Markers
{
    public interface ICommand
    {
        Guid Id { get; set; }
    }
}