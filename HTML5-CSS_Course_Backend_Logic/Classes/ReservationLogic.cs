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
            repo.Create(item);
        }

        public void Delete(string id)
        {
            repo.Delete(id);
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
        }
    }
}