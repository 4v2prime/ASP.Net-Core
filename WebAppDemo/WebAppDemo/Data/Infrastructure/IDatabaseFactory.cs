namespace WebAppDemo.Data.Infrastructure
{
    public interface IDatabaseFactory
    {
        UM_DBContext Get();
    }
}
