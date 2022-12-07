using HTML5_CSS_Course_Backend_Models;

namespace HTML5_CSS_Course_Backend_Logic
{
    public interface ITableLogic : ILogic<Table, long>
    {
        IEnumerable<Table> Free(DateTime start, DateTime stop);
        void Enable(string name);
        void Disable(string name);
        IEnumerable<Table> GetByState(bool state);
        Table? GetByName(string name);
        void DeleteByName(string name);

    }
}