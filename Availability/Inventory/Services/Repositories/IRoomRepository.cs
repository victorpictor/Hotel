using System.Collections.Generic;
using Inventory.Management;

namespace Inventory.Services.Repositories
{
    public interface IRoomRepository
    {
        List<Room> Get(RoomType type);
    }
}