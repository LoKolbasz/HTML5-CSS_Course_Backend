using HTML5_CSS_Course_Backend_Models;

namespace HTML5_CSS_Course_Backend_Logic
{
    public interface ITableLogic : ILogic<Table, long>
    {
        IEnumerable<Table> Free(string start, string stop);
        IEnumerable<Reservation> Get(string start, string stop);
        void Enable(string name);
        void Disable(string name);
        IEnumerable<Table> GetByState(bool state);
        IEnumerable<Table> GetByName(string name);
    }
}