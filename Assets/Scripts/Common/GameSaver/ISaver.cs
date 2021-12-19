namespace Common.GameSaver
{
    public interface ISaver<T>
    {
        bool IsNull();
        T Get();
        void Set(T value);
    }
}