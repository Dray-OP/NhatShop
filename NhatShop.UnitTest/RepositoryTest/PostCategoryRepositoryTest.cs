using Microsoft.VisualStudio.TestTools.UnitTesting;
using NhatShop.Data.Infrastructure;
using NhatShop.Data.Repositories;
using NhatShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhatShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        IDbFactory dbFactory;
        IPostCategoryRepository objRepository;
        IUnitOfWork unitOfWork;
        // chạy đầu
        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory); 
        }
        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var list = objRepository.GetAll().ToList();

            Assert.AreEqual(7, list.Count);
        }

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test category";
            category.Alias = "Test_category";
            category.Status = true;

            var result = objRepository.Add(category);
            unitOfWork.Commit();
            //so sanh
            Assert.IsNotNull(result);
            Assert.AreEqual(7, result.ID);
        }
    }
}
