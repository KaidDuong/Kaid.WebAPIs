using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Data.Respositories;
using Kaid.WebAPI.Model.Models;
using System.Collections.Generic;

namespace Kaid.WebAPI.Service
{
    public interface IPostService
    {
        void Add(Post post);

        void Update(Post post);

        void Delete(Post post);

        void Delete(int id);

        IEnumerable<Post> GetAll();

        IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow);

        Post GetById(int id);

        IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);

        void SaveChanges();
    }

    public class PostService : IPostService
    {
        private IPostRespository _postRespository;
        private IUnitOfWork _unitOfWork;

        public PostService(IPostRespository postRespository, IUnitOfWork unitOfWork)
        {
            this._postRespository = postRespository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Post post)
        {
            _postRespository.Add(post);
        }

        public void Delete(Post post)
        {
            _postRespository.Delete(post);
        }

        public void Delete(int id)
        {
            _postRespository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return this._postRespository.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            //TODO: SELECT all posts by tag
            return _postRespository.GetMultiPaging
                (x => x.Status, out totalRow, page, pageSize);
        }

        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _postRespository.GetMultiPaging
                (x => x.Status, out totalRow, page, pageSize);
        }

        public Post GetById(int id)
        {
            return _postRespository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postRespository.Update(post);
        }
    }
}