using NhatShop.Data.Infrastructure;
using NhatShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace NhatShop.Data.Repositories
{
    // có phương thức nào khác RepositoryBase thì khởi tạo ở interface IProductCategoryRepository
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        IEnumerable<ProductCategory> GetListAlias(string alias); 
    }
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }
        //IEnumerable mộ mảng chỉ để đọc
        public IEnumerable<ProductCategory> GetListAlias(string alias)
        {
            return this.DbContext.ProductCategories.Where(x => x.Alias == alias);
        }
    }
}
