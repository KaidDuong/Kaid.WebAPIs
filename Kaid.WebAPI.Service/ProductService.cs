using Kaid.WebAPI.Common;
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
        private ITagRepository _tagRepository;
        private IProductTagRepository _productTagRepository;
        private IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository,
                              IUnitOfWork unitOfWork,
                              IProductTagRepository productTagRepository,
                              ITagRepository tagRepository
                              )
        {
            this._productRepositories = productRepository;
            this._unitOfWork = unitOfWork;
            this._productTagRepository = productTagRepository;
            this._tagRepository = tagRepository;
        }
        public Product Add(Product product)
        {
            var entity = _productRepositories.Add(product);
            _unitOfWork.Commit();

            if (!string.IsNullOrEmpty(entity.Tags))
            {
                string[] tags = entity.Tags.Split(',');

                for(var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsingString(tags[i]);

                    if (_tagRepository.Count(k => k.ID == tagId) == 0)
                    {
                        Tag tag = new Tag
                        {
                            ID = tagId,
                            Name = tags[i],
                            Type = CommonConstants.ProductTag
                        };
                        _tagRepository.Add(tag);
                    }

                    ProductTag productTag = new ProductTag {
                        ProductID = entity.ID,
                        TagID= tagId
                    };
                    _productTagRepository.Add(productTag);
                }
              
            }
            return entity;
            
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
        
            if (!string.IsNullOrEmpty(product.Tags))
            {
                string[] tags = product.Tags.Split(',');

                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsingString(tags[i]);

                    if (_tagRepository.Count(k => k.ID == tagId) == 0)
                    {
                        Tag tag = new Tag
                        {
                            ID = tagId,
                            Name = tags[i],
                            Type = CommonConstants.ProductTag
                        };
                        _tagRepository.Add(tag);
                    }
                    _productTagRepository.DeleteMulti(k => k.ProductID == product.ID);
                    ProductTag productTag = new ProductTag
                    {
                        ProductID = product.ID,
                        TagID = tagId
                    };
                    _productTagRepository.Add(productTag);
                }

            }
        }
    }
}
