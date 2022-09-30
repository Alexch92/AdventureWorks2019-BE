namespace AdventureWorks2019BE.Services
{
    public class BaseService<T>
    {
        protected T repository;

        public BaseService()
        {
            this.repository = (T)Activator.CreateInstance(typeof(T), null);
        }
    }
}
