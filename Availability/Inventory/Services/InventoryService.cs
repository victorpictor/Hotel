using System;
using System.Collections.Generic;
using System.Linq;
using Inventory.HotelRoom;
using Inventory.Services.Repositories;

namespace Inventory.Services
{
    public class InventoryService
    {
        private IBookRoomRequestsRepository requests;
        private IRoomRepository rooms;

        public InventoryService(IBookRoomRequestsRepository requests, IRoomRepository rooms)
        {
            this.requests = requests;
            this.rooms = rooms;
        }

        public List<RoomType> AllRooms(DateTime from, DateTime to)
        {
            var rs = rooms.Get(RoomType.King);
            rs.AddRange(rooms.Get(RoomType.Queen));

            var notBookedYet = rs.Where(r => r.IsAvailable(@from, to));
            
            var notRequestedYet = notBookedYet.Where(nb => requests.Exists(nb.Id, from,to));

            return notRequestedYet.Select(nb => nb.Type).Distinct().ToList();
        }

    }
}