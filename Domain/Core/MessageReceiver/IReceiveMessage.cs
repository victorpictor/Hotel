namespace Core.MessageReceiver
{
    public interface IReceiveMessage<T>
    {
        void Receive(T message);
    }
}