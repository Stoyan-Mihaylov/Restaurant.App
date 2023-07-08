namespace MentorMate.Restaurant.Business.Caches
{
    public abstract class BaseCache<T>
    {
        public T Data { get; private set; }

        public void SetCache(T data)
        {
            Data = data;
        }

        public abstract void Init(string jsonData);
    }
}
