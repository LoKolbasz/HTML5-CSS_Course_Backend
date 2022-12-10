using System.ComponentModel.DataAnnotations;
using HTML5_CSS_Course_Backend_Models;
using HTML5_CSS_Course_Backend_Repository;

namespace HTML5_CSS_Course_Backend_Logic
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
            if (ReadAll().Contains(item))
            {
                throw new ArgumentException("The item you are trying to add already exists");
            }
            Validator.ValidateObject(item, new ValidationContext(item), true);
            repo.Create(item);
        }

        public void Delete(long id)
        {
            if (ReadAll().FirstOrDefault(t => t.id == id) == null) throw new NullReferenceException("The item you are trying to delete doesn't exist");
            repo.Delete(id);
        }
        public void DeleteByName(string name)
        {
            var item = GetByName(name);
            if (item == null) throw new NullReferenceException();
            repo.Delete(item.id);
        }

        public void Disable(string name)
        {
            GetByName(name)!.isEnabled = true;
        }

        public void Enable(string name)
        {
            GetByName(name)!.isEnabled = false;
        }

        public IEnumerable<Table> Free(DateTime start, DateTime stop)
        {
            return ReadAll()
                   .Where(t => t.isEnabled
                   && t.reservations!.Where(t => t.ReservationsIntersect(start, stop)).Count() == 0)
                   .AsEnumerable();
        }

        public Table GetByName(string name)
        {
            Table? result;
            try
            {
                var tmp = ((TableRepository)repo).ReadByName(name);
                result = new Table() { id = tmp.id, name = tmp.name, capacity = tmp.capacity};
            }
            catch (Exception e)
            {
                throw new QuerryFailedException(e);
            }
            if (result == null) throw new NullReferenceException();
            return result!;
        }

        public IEnumerable<Table> GetByState(bool state)
        {
            IEnumerable<Table> result;
            try
            {
                result = ReadAll()
                        .Where(t => t.isEnabled == state)
                        .AsEnumerable();
            }
            catch (Exception e)
            {
                throw new QuerryFailedException(e);
            }
            if (result == null || result.Count() == 0) throw new NullReferenceException();
            return result;
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
            Validator.ValidateObject(item, new ValidationContext(item), true);
            repo.Update(item);
        }
    }
}