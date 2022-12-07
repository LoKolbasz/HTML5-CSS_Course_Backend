using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using HTML5_CSS_Course_Backend_Repository.Database;

namespace HTML5_CSS_Course_Backend_Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected ReservationContext ctx;

        protected Repository(ReservationContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        public void Delete(object id)
        {
            T? toBeRemoved = Read(id);
            if (toBeRemoved != null)
            { 
                ctx.Set<T>().Remove(toBeRemoved);
                ctx.SaveChanges();
            }
        }

        public abstract T? Read(object id);

        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }

        public abstract void Update(T item);
        protected void SetProps(T old, T provided)
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                object? val = prop.GetValue(provided);
                if (!(val is null))
                {
                    if (!prop.IsDefined(typeof(NotMappedAttribute)))
                    {
                        prop.SetValue(old, val);
                    }
                }
            }
            ctx.SaveChanges();
        }
    }
}