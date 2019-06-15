using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Data.Repositories;
using Kaid.WebAPI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaid.WebAPI.Service
{
    public interface IProductService
    {
        Product Add(Product product);

        void Update(Product product);

        Product Delete(int id);

        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAll(string keyword);
        IEnumerable<Product> GetAllByCategoryId(int parentId);

        Product GetById(int id);

        void SaveChanges();
    }
    public class ProductService : IProductService
    {
        private IProductRepository _productRepositories;
        private IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this._productRepositories = productRepository;
            this._unitOfWork = unitOfWork;
        }
        public Product Add(Product product)
        {
           return  _productRepositories.Add(product);
            
        }

        public Product Delete(int id)
        {
            return _productRepositories.Delete(id);
            
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepositories.GetAll();
        }

        public IEnumerable<Product> GetAll(string keyword)
        {
            return (!string.IsNullOrEmpty(keyword)) ?
                   _productRepositories.GetMulti(k => k.Name.Contains(keyword) || k.Content.Contains(keyword) || k.Description.Contains(keyword))
                   :_productRepositories.GetAll();
        }

        public IEnumerable<Product> GetAllByCategoryId(int CategoryId)
        {
            return _productRepositories.GetMulti(k => k.Status && k.CategoryID == CategoryId);
        }

        public Product GetById(int id)
        {
            return _productRepositories.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Product product)
        {
            _productRepositories.Update(product);
        }
    }
}
