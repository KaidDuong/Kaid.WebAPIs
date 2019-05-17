using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Data.Repositories;
using Kaid.WebAPI.Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Kaid.WebAPI.UnitTest.RespositoryTest
{
    [TestClass]
    public class PostCategoryRespositoryTest
    {
        private IDbFactory _dbFactory;
        private IPostCategoryRespository _objRespository;
        private IUnitOfWork _unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            _dbFactory = new DbFactory();
            _objRespository = new PostCategoryRepository(_dbFactory as DbFactory);
            _unitOfWork = new UnitOfWork(_dbFactory);
        }

        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var list = _objRespository.GetAll().ToList();
            Assert.AreEqual(6, list.Count);
        }

        [TestMethod]
        public void PostCategory_Respository_Create()
        {
            PostCategory category = new PostCategory
            {
                Name = "Test category",
                Alias = "Test-category",
                Status = true
            };
            var result = _objRespository.Add(category);
            _unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(6, result.ID);
        }
    }
}