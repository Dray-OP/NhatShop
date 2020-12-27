using NhatShop.Data.Infrastructure;
using NhatShop.Model.Models;

namespace NhatShop.Data.Repositories
{
    public interface IProductRepository
    {

    }
    public class ProductRepository : RepositoryBase<Product> , IProductRepository
    {   
        public ProductRepository(IDbFactory dbFactory)
            : base(dbFactory) 
        {

        }
    }
}
