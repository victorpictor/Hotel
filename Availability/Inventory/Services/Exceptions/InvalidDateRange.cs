using System;

namespace Inventory.Services.Exceptions
{
    public class InvalidDateRange : Exception
    {
        public InvalidDateRange(string message)
            : base(message)
        {
        }
    }
}