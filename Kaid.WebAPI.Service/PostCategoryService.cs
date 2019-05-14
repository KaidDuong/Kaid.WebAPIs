using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Data.Respositories;
using Kaid.WebAPI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaid.WebAPI.Service
{
    public interface IPostCategoryService
    {
        void Add(PostCategory postCategory);
        void Update(PostCategory postCategory);
      
        void Delete(int id);
        IEnumerable<PostCategory> GetAll();
        IEnumerable<PostCategory> GetAllByParentId(int parentId);
        PostCategory GetById(int id);
        void SaveChanges();
    }
    public class PostCategoryService : IPostCategoryService
    {
        private IPostCategoryRespository _postCategoryRespository;
        private IUnitOfWork _unitOfWork;
        public PostCategoryService( PostCategoryRespository postCategoryRespository, UnitOfWork unitOfWork)
        {
            this._postCategoryRespository = postCategoryRespository;
            this._unitOfWork = unitOfWork ;
        }
        public void Add(PostCategory postCategory)
        {
            _postCategoryRespository.Add(postCategory);
        }

        public void Delete(int id)
        {
            _postCategoryRespository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRespository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParentId(int parentId)
        {
            return _postCategoryRespository.GetMulti(k => k.Status && k.ParentID == parentId);
        }

        public PostCategory GetById(int id)
        {
            return _postCategoryRespository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(PostCategory postCategory)
        {
            _postCategoryRespository.Update(postCategory);
        }
    }
}
