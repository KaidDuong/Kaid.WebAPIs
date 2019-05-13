namespace Kaid.WebAPI.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private KaidDbContext dbContext;

        public KaidDbContext Init()
        {
            return dbContext ?? (dbContext = new KaidDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}