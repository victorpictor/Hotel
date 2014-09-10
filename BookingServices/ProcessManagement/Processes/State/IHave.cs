namespace ProcessManagement.Processes.State
{
    public interface IHave<T>
    {
        T State { get; set; }
    }
}