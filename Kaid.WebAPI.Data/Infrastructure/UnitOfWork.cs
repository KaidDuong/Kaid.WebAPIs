namespace Kaid.WebAPI.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private KaidDbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public KaidDbContext DbContext
        {
            get
            {
                return dbContext ??
                  (dbContext = dbFactory.Init());
            }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}