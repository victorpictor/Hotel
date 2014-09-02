using Inventory.HotelRoom;
using Inventory.Services.Repositories;

namespace Inventory.Services
{
    public interface IAvailabilitySessionService
    {
        void Store(AvailableRooms ar);
        AvailableRooms Get(string guid);
    }

    public class AvailabilitySessionService : IAvailabilitySessionService
    {
        private ISessionRepository<AvailableRooms> session;

        public AvailabilitySessionService(ISessionRepository<AvailableRooms> session)
        {
            this.session = session;
        }

        public void Store(AvailableRooms ar)
        {
            session.Store(ar);
        }

        public AvailableRooms Get(string guid)
        {
            return session.Get(guid);
        }
    }
}