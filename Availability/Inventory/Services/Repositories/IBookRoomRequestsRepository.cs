using System.Collections.Generic;
using Inventory.Holds;

namespace Inventory.Services.Repositories
{
    public interface IBookRoomRequestsRepository
    {
        List<SubmittedBookRoomRequest> Get();
    }
}