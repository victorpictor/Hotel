using Messages.Markers;

namespace Messages.Sender
{
    public interface IEventPublisher
    {
        void Publish(IEvent @event);
    }
}