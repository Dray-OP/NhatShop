namespace NhatShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private NhatShopDbContext dbContext;

        public NhatShopDbContext Init()
        {
            // ?? nếu null thì khởi tạo dbContext
            return dbContext ?? (dbContext = new NhatShopDbContext());
        }

        protected override void DisposeCore()
        {
            // khác null thì dispose()
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}