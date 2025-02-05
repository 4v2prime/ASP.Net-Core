using WebAppDemo.Data.Infrastructure;

namespace WebAppDemo.Data.Infrastructure
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private readonly UM_DBContext dbContext;

        public DatabaseFactory(UM_DBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public UM_DBContext Get()
        {
            return dbContext;
        }


    }
}