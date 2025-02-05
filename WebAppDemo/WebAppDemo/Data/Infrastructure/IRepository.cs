using System.Linq.Expressions;

namespace WebAppDemo.Data.Infrastructure
{

    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(int id);
        IQueryable<T> GetAllByQuery();

        IQueryable<T> Where(Expression<Func<T, bool>> where);
    }
}
