using System;

namespace NhatShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        NhatShopDbContext Init();
    }
}