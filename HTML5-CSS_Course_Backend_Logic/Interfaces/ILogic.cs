namespace HTML5_CSS_Course_Backend_Logic
{
    public interface ILogic<T, U> where T : class, new() // T is the class, U is the id type
    {
        void Create(T item);
        IQueryable<T> ReadAll();
        void Update(T item);
        T? Read(U id);
        void Delete(U id);
    }
}