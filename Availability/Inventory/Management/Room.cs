using System.Collections.Generic;

namespace Inventory.Management
{
    public class Room
    {
        public int Identity;

        public RoomType Type;

        public List<BookedOnRange> BookedOn;
    }
}