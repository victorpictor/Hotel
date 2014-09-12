using Core.Markers;

namespace Core.Sender
{
    public interface IEventPublisher
    {
        void Publish(IEvent @event);
    }
}