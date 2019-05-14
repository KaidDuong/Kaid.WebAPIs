namespace Kaid.WebAPI.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}