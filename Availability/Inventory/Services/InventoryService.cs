using System;
using System.Collections.Generic;
using System.Linq;
using Core.Booking.TheRoom;
using Inventory.Services.Repositories;

namespace Inventory.Services
{
    public interface IInventoryService
    {
        List<RoomType> AllRooms(DateTime from, DateTime to);
    }

    public class InventoryService : IInventoryService
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

            var notRequestedYet = notBookedYet.Where(nb => !requests.Exists(nb.Id, from, to)).ToList();

            return notRequestedYet.Select(nb => nb.Type).Distinct().ToList();
        }

    }
}