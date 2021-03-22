using NhatShop.Data.Infrastructure;
using NhatShop.Data.Repositories;
using NhatShop.Model.Models;
using System.Collections.Generic;

namespace NhatShop.Service
{
    public interface IPostCategoryService
    {
        PostCategory Add(PostCategory postCategory);
        void Update(PostCategory postCategory);
        PostCategory Delete(int id);
        IEnumerable<PostCategory> GetAll();
        IEnumerable<PostCategory> GetAllByParentId(int parentId);
        PostCategory GetById(int id);
        //IEnumerable<PostCategory> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);
        void SaveChanges();
    }
    public class PostCategoryService : IPostCategoryService
    {
        IPostCategoryRepository _postCategoryRepository;
        IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryRepository postCategoryRepository,IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitOfWork;
        }
        public PostCategory Add(PostCategory postCategory)
        {
            return _postCategoryRepository.Add(postCategory);
        }

        public PostCategory Delete(int id)
        {
            return _postCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            //return _postCategoryRepository.GetAll(new string[] { "PostCategories"});
            return _postCategoryRepository.GetAll();
        }
        // gọi interface nhưng lấy phương thức khác
        // nhiệm vụ của interface là truyền vào một cái gì đó
        public IEnumerable<PostCategory> GetAllByParentId(int parentId)
        {
            return _postCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public PostCategory GetById(int id)
        {
            return _postCategoryRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(PostCategory postCategory)
        {
            _postCategoryRepository.Update(postCategory);
        }
    }
}
