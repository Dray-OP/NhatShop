using NhatShop.Data.Infrastructure;
using NhatShop.Data.Repositories;
using NhatShop.Model.Models;
using System;
using System.Collections.Generic;

namespace NhatShop.Service
{
    public interface IPostService
    {
        void Add(Post post);
        void Update(Post post);
        void Delete(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow);
        IEnumerable<Post> GetAllByCategoryPaging(int categoryID, int page, int pageSize, out int totalRow);
        Post GetById(int id);
        IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);
        void SaveChanges();
    }

    // tất cả liên quan đến post
    public class PostService : IPostService
    {
        // biến của class thì thêm dấu gạch dưới, nội bộ thì không
        // gọi các phương thức bên trong responsitory để thực hiện phương thức
        IPostRepository _postRepository;
        IUnitOfWork _unitOfWork;

        // nội bộ contructor
        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;  
        }
        public void Add(Post post)
        {
            _postRepository.Add(post);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll(new string[] {"PostCategory"});
        }

        public IEnumerable<Post> GetAllByCategoryPaging(int categoryID, int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status && x.CategoryID == categoryID, out totalRow, page, pageSize,new string[] {"PostCategory" });
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetAllByTag(tag, page, pageSize, out totalRow);
        }

        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }
        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}
