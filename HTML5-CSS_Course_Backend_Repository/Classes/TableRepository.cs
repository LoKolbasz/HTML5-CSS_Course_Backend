using HTML5_CSS_Course_Backend_Models;
using HTML5_CSS_Course_Backend_Repository.Database;

namespace HTML5_CSS_Course_Backend_Repository
{
    public class TableRepository : Repository<Table>, IRepository<Table>
    {
        public TableRepository(ReservationContext ctx) : base(ctx)
        {
        }

        public override Table? Read(object id)
        {
            if (ctx.tables == null) throw new NullReferenceException();
            else if (id is long) return ctx.tables.FirstOrDefault(t => t.id == (long)id);
            else throw new ArgumentException("Invalid object type");
        }

        public override void Update(Table item)
        {
            Table? old = Read(item.id);
            if (old != null) SetProps(old, item);
            else throw new KeyNotFoundException("No file exists that could be updated");
        }
        public Table? ReadByName(string name)
        {
            if (ctx.tables == null) throw new NullReferenceException();
            else
            {
                var results = ctx.tables.Where(t => t.name == name);
                if (results.Count() > 1) throw new AmbiguityException("There were more than 1 tables found with the specified name");
                return results.FirstOrDefault();
            }
        }
    }
    public class AmbiguityException : Exception
    {
        public AmbiguityException()
        {
        }

        public AmbiguityException(string? message) : base(message)
        {
        }

        public AmbiguityException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}