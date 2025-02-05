using Microsoft.EntityFrameworkCore;
using WebAppDemo.Data.Model;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using System.Linq.Expressions;
namespace WebAppDemo.Data.Infrastructure
{
    public partial class UM_DBContext : DbContext
    {
        private UM_DBContext _dbContext;
        public UM_DBContext() { }

        public UM_DBContext(DbContextOptions<UM_DBContext> options) : base(options) { }

        public DbSet<tblUser> tblUser { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(DatabaseSettings.SQLConnectionString, x => x.());
        //}
        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }
        //protected UM_DBContext DataContext
        //{
        //    get { return _dbContext ?? (_dbContext = DatabaseFactory.Get()); }
        //}
        public void Commit()
        {
            this.SaveChanges();
        }
    }
}
