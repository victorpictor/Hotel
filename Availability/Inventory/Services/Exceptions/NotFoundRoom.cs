using System;

namespace Inventory.Services.Exceptions
{
    public class NotFoundRoom: Exception
    {
        public NotFoundRoom(string message)
            : base(message)
        {
        }
    }
}