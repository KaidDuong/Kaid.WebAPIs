using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Data.Respositories;
using Kaid.WebAPI.Model.Models;
using System.Collections.Generic;

namespace Kaid.WebAPI.Service
{
    public interface IPostCategoryService
    {
        PostCategory Add(PostCategory postCategory);

        void Update(PostCategory postCategory);

        PostCategory Delete(int id);

        IEnumerable<PostCategory> GetAll();

        IEnumerable<PostCategory> GetAllByParentId(int parentId);

        PostCategory GetById(int id);

        void SaveChanges();
    }

    public class PostCategoryService : IPostCategoryService
    {
        private IPostCategoryRespository _postCategoryRespository;
        private IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryRespository postCategoryRespository, IUnitOfWork unitOfWork)
        {
            this._postCategoryRespository = postCategoryRespository;
            this._unitOfWork = unitOfWork;
        }

        public PostCategory Add(PostCategory postCategory)
        {
           return _postCategoryRespository.Add(postCategory);
        }

        public PostCategory Delete(int id)
        {
        return    _postCategoryRespository.Delete(id);
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