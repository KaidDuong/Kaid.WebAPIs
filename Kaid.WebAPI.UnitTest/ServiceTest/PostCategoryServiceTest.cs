using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Data.Repositories;
using Kaid.WebAPI.Model.Models;
using Kaid.WebAPI.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaid.WebAPI.UnitTest.ServiceTest
{
    [TestClass]
  public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRespository> _mockRespository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _categoryService;
        private List<PostCategory> _postCategories;

        [TestInitialize]
        public void Intialize( )
        {
            _mockRespository = new Mock<IPostCategoryRespository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _categoryService = new PostCategoryService(_mockRespository.Object, _mockUnitOfWork.Object);
            _postCategories = new List<PostCategory>()
            {
                new PostCategory(){ID=1, Name="DM1", Status=true},
                 new PostCategory(){ID=2, Name="DM2", Status=true},
                  new PostCategory(){ID=3, Name="DM3", Status=true},
            };
        }
        [TestMethod]
        public void PostCategory_Service_Create()
        {
            PostCategory postCategory = new PostCategory
            {
                ID=1,
                Name = "test",
                Alias = "test",
                Status = true,
            };
            _mockRespository.Setup(k=>k.Add(postCategory))
                .Returns((PostCategory p)=>{
                    p.ID = 1;
                    return p;
            });
            var result = _categoryService.Add(postCategory);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }
        [TestMethod]
        public void PostCategory_Service_GetAll()
        {

            //SETUP METHOD
            _mockRespository.Setup(k => k.GetAll(null)).Returns(_postCategories);

            //call action
            var result = _categoryService.GetAll() as List<PostCategory>;

            //compare
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }
    }
}
