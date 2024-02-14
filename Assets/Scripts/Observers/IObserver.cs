public interface IObserver<T>
{
    void OnUpdated(T subject);
}