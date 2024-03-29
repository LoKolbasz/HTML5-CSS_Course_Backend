using System.ComponentModel.DataAnnotations;
using HTML5_CSS_Course_Backend_Models;
using HTML5_CSS_Course_Backend_Repository;

namespace HTML5_CSS_Course_Backend_Logic
{
    public class ReservationLogic : IReservationLogic
    {
        IRepository<Reservation> repo;

        public ReservationLogic(IRepository<Reservation> repo)
        {
            this.repo = repo;
        }

        public void Create(Reservation item)
        {
            if (ReadAll().ToList().FirstOrDefault(t => t.ReservationsIntersect(item.begin, item.end))== null) //&& t.table!.Equals(item.table)) == null)
            {
                Validator.ValidateObject(item, new ValidationContext(item), true);
                repo.Create(item);
            }
            else
            {
                throw new ArgumentException("The table is already reserved");
            }
        }

        public void Delete(string id)
        {
            repo.Delete(id);
        }

        public IEnumerable<Reservation> Get(DateTime start, DateTime stop)
        {
            return ReadAll()
                   .Where(t => t.ReservationsIntersect(start, stop))
                   .AsEnumerable();
        }

        public Reservation? Read(string id)
        {
            return repo.Read(id);
        }

        public IQueryable<Reservation> ReadAll()
        {
            return repo.ReadAll().AsQueryable();
        }

        public void Update(Reservation item)
        {
            repo.Update(item);
            Validator.ValidateObject(item, new ValidationContext(item), true);
        }
    }
}