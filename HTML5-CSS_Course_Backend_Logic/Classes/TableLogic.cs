using HTML5_CSS_Course_Backend_Models;
using HTML5_CSS_Course_Backend_Repository;

namespace HTML5_CSS_Course_Backend_Logic.Classes
{
    public class TableLogic : ITableLogic
    {
        IRepository<Table> repo;

        public TableLogic(IRepository<Table> repo)
        {
            this.repo = repo;
        }

        public void Create(Table item)
        {
            repo.Create(item);
        }

        public void Delete(long id)
        {
            repo.Delete(id);
        }

        public void Disable(string name)
        {
            throw new NotImplementedException();
        }

        public void Enable(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Table> Free(string start, string stop)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> Get(string start, string stop)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Table> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Table> GetByState(bool state)
        {
            throw new NotImplementedException();
        }

        public Table? Read(long id)
        {
            return repo.Read(id);
        }

        public IQueryable<Table> ReadAll()
        {
            return repo.ReadAll().AsQueryable();
        }

        public void Update(Table item)
        {
            repo.Update(item);
        }
    }
}