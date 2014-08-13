using Messages.Markers;

namespace Messages.Sender
{
    public interface ICommandSerder
    {
        void Send(ICommand command);
    }
}