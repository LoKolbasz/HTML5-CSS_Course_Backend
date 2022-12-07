using HTML5_CSS_Course_Backend_Models;
using HTML5_CSS_Course_Backend_Repository.Database;

namespace HTML5_CSS_Course_Backend_Repository
{
    public class ReservationRepository : Repository<Reservation>, IRepository<Reservation>
    {
        public ReservationRepository(ReservationContext ctx) : base(ctx)
        {
        }

        public override Reservation? Read(object id)
        {
            if (ctx.reservations == null) throw new NullReferenceException();
            else if (id is long) return ctx.reservations.FirstOrDefault(t => t.id == (string)id);
            else throw new ArgumentException("Invalid object type");
        }

        public override void Update(Reservation item)
        {
            if (item.id != null)
            {
                Reservation? old = Read(item.id);
                if (old != null) SetProps(old, item);
                else throw new KeyNotFoundException("No file exists that could be updated");
            }
            else
            {
                throw new ArgumentException("The id of the object to be updated was null");
            }
        }
    }
}