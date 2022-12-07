using HTML5_CSS_Course_Backend_Models;

namespace HTML5_CSS_Course_Backend_Logic
{
    public interface IReservationLogic : ILogic<Reservation, string>
    {
        IEnumerable<Reservation> Get(DateTime start, DateTime stop);
    }
}