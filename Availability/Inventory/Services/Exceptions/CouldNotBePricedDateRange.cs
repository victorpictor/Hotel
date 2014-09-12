using System;

namespace Inventory.Services.Exceptions
{
    public class CouldNotBePricedDateRange: Exception
    {
        public CouldNotBePricedDateRange()
        {
        }

        public CouldNotBePricedDateRange(string message)
            : base(message)
        {
        } 
    }
}