namespace HTML5_CSS_Course_Backend_Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> ReadAll();
        T? Read(object id);
        void Create(T item);
        void Update(T item);
        void Delete(object id);
    }
}