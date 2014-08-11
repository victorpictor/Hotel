using System;
using System.Collections.Generic;
using System.Linq;
using Inventory.Management;
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

        public List<int> AllRooms(DateTime from, DateTime to)
        {
            var rs = rooms.Get(RoomType.All);

            var notBookedYet = rs.Where(r => r.IsAvailable(from,to));

            if (notBookedYet.Any())
            {
                var reqs = requests.Get();

                notBookedYet = notBookedYet.Where(
                    nb => reqs.All(
                        r => r.RoomId != nb.Id &&
                             r.StartDate.Date != from.Date &&
                             r.EndDate.Date != to));
            }

            return notBookedYet.Select(nb => nb.Id).ToList();
        }

    }
}