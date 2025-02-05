namespace WebAppDemo.Data.Repository
{
    using Data.Model;
    using WebAppDemo.Data.Infrastructure;

    public interface ItblUserRepository: IRepository<tblUser>
    {
        public class tblUserRepository : RepositoryBase<tblUser>, ItblUserRepository
        {
            public tblUserRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
        }



    }
    
}
