using Core.Markers;

namespace Core.Sender
{
    public interface ICommandSerder
    {
        void Send(ICommand command);
    }
}