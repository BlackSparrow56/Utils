namespace ESparrow.Utils.Collections.Generic.Interfaces
{
    public interface IQueue<T>
    {
        void Enqueue(T value);
        T Dequeue();

        bool IsEmpty
        {
            get;
        }
    }
}
