namespace WebAppDemo.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private UM_DBContext datacontext;

        public UnitOfWork(IDatabaseFactory databasefactory)
        { 
            this.databaseFactory = databasefactory;
        }

        protected UM_DBContext DataContext
        {
            get { return datacontext ?? (datacontext = databaseFactory.Get()); }
        }
        public void Commit()
        {
            DataContext.Commit();
        }
    }
}
