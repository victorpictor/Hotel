using System;
using Core.Markers;

namespace Core.Payments
{
    public class ChangeCard:ICommand
    {
        public Guid Id { get; set; }
    }
}