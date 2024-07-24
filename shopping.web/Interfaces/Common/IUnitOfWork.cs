namespace shopping.web.Interfaces.Common
{
    public interface IUnitOfWork
    {
        Task SaveChanges();
    }
}
