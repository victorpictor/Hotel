using System.Collections.Generic;
using Core.Markers;
using Core.Sender;

namespace BookingServicesPm.Spec
{
    public class InMemoryMessageSender : ICommandSerder
    {
        public List<ICommand> Sent = new List<ICommand>();

        public void Send(ICommand command)
        {
            Sent.Add(command);
        }
    }
}