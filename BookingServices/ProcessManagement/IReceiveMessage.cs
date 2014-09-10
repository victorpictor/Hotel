namespace ProcessManagement
{
    public interface IReceiveMessage<T>
    {
        void Receive(T message);
    }
}