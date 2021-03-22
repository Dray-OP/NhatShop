using System;
using System.Collections;
using System.Collections.Generic;
using NhatShop.Data.Infrastructure;
using NhatShop.Model.Models;
using System.Linq;

namespace NhatShop.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow);
    }

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        public IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.Posts
                        join pt in DbContext.PostTags
                        on p.ID equals pt.PostID
                        where pt.TagID == tag && p.Status
                        orderby p.CreatedDate descending
                        select p;
            // số lượng bản ghi
            totalRow = query.Count();
            // vd query từ trang số 1 (pageIndex) -1 nhân số lượng trong 1 bảng ghi(pageSize) => ra số lượng bản ghi bỏ qua
            // rồi lấy số lương trong 1 bản ghi (pageSize)
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return query;
        }
    }
}