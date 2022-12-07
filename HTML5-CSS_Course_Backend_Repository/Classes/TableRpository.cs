using HTML5_CSS_Course_Backend_Models;
using HTML5_CSS_Course_Backend_Repository.Database;

namespace HTML5_CSS_Course_Backend_Repository
{
    public class TableRpository : Repository<Table>, IRepository<Table>
    {
        public TableRpository(ReservationContext ctx) : base(ctx)
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
    }
}