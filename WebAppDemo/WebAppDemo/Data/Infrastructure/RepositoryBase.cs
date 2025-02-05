using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace WebAppDemo.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        private UM_DBContext _dbContext;

        private readonly DbSet<T> _dbSet;
        //protected UM_DBContext DataContex { get; private set; }
        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            _dbContext = DatabaseFactory.Get();
            //_dbSet = (DbSet<T>) _dbContext.Set <T> ();
            _dbSet = _dbContext.Set <T> ();
        }
        protected IDatabaseFactory DatabaseFactory 
        {
            get;
            private set;
        }

        protected UM_DBContext DataContext
        { 
         get { return _dbContext ?? (_dbContext = DatabaseFactory.Get()); }
        }
        public virtual void Add(T entity)
        { 
            _dbSet.Add(entity);
            //DataContext.SaveChanges();
        }
        public virtual void Update(T entity)
        { 
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity) 
        {
            _dbSet.Remove(entity);
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        
        public virtual IQueryable<T> GetAllByQuery()
        {
            return _dbSet.AsQueryable();
        }
        public virtual IQueryable<T> Where(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where);
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            _dbSet.RemoveRange(_dbSet.Where(where).AsQueryable());
        }

    }
}
