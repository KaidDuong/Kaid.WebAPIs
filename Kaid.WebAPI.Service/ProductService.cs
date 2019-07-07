﻿using Kaid.WebAPI.Common;
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
        IEnumerable<Product> GetLatestProduct(int top);
        IEnumerable<Product> GetTopSaleProduct(int top);
        IEnumerable<Product> GetProductsByCategoryIdPaging(int categoryId, int page, int pageSize, string sort, out int totalRow);
        IEnumerable<Product> GetProductsByNamePaging(string keyword, int page, int pageSize, string sort, out int totalRow);
        IEnumerable<string> GetProductsByName(string name);  
        Product GetById(int id);
        IEnumerable<Product> GetRelatedProducts(int id, int numberOfRelatedProducts);
        IEnumerable<Tag> GetTagsBy(int id);
        IEnumerable<Product> GetProductsByTagIdPaging(string tagId, int page, int pageSize, out int totalRow);
        void IncreaseView(int id);
        Tag GetTag(string tagId);
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

        public IEnumerable<Product> GetLatestProduct(int top)
        {
           return _productRepositories.GetMulti(k => k.Status).OrderByDescending(k => k.CreateDate).Take(top);
        }

        public IEnumerable<Product> GetProductsByCategoryIdPaging(int categoryId, int page, int pageSize, string sort, out int totalRow)
        {
            var query= _productRepositories.GetMulti(k => k.Status && k.CategoryID == categoryId);

            totalRow = query.Count();

            switch (sort)
            {
                case "popular":
                    {
                        query.OrderByDescending(k => k.ViewCount);
                        break;
                    }
                case "discount":
                    {
                        query.OrderByDescending(k => k.PromotionPrice.HasValue);
                        break;
                    }
                case "price":
                    {
                        query.OrderBy(k => k.Price);
                        break;
                    }
                default :
                    {
                        query.OrderByDescending(k => k.CreateDate);
                        break;
                    }
            }

            return query.Skip((page - 1) * pageSize).Take(pageSize);

        }

        public IEnumerable<string> GetProductsByName(string name)
        {
            return _productRepositories.GetMulti(k => k.Name.Contains(name)).Select(k => k.Name);
        }

        public IEnumerable<Product> GetProductsByNamePaging(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _productRepositories.GetMulti(k => k.Status && k.Name.Contains(keyword));

            totalRow = query.Count();

            switch (sort)
            {
                case "popular":
                    {
                        query.OrderByDescending(k => k.ViewCount);
                        break;
                    }
                case "discount":
                    {
                        query.OrderByDescending(k => k.PromotionPrice.HasValue);
                        break;
                    }
                case "price":
                    {
                        query.OrderBy(k => k.Price);
                        break;
                    }
                default:
                    {
                        query.OrderByDescending(k => k.CreateDate);
                        break;
                    }
            }

            return query.Skip((page - 1) * pageSize).Take(pageSize);

        }

        public IEnumerable<Tag> GetTagsBy(int id)
        {
            return _productTagRepository.GetMulti(k=>k.ProductID==id,new string[] { "Tag"}).Select(x=>x.Tag);
        }

        public IEnumerable<Product> GetRelatedProducts(int id, int numberOfRelatedProducts)
        {
            var categoriId = _productRepositories.GetSingleById(id).CategoryID;

            return 
                _productRepositories
                .GetMulti(k => k.Status && k.ID != id && k.CategoryID == categoriId)
                .OrderByDescending(k => k.CreateDate)
                .Take(numberOfRelatedProducts);
        }

        public IEnumerable<Product> GetTopSaleProduct(int top)
        {
            return _productRepositories.GetMulti(k => (k.Status) && k.HotFlag==true ).OrderByDescending(k => k.CreateDate).Take(top);

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

        public IEnumerable<Product> GetProductsByTagIdPaging(string tagId, int page, int pageSize, out int totalRow)
        {
            var model = _productRepositories.GetProductsFromTag(tagId);

            totalRow = model.Count();

            return model.OrderByDescending(k => k.CreateDate).Skip((page - 1) * pageSize).Take(pageSize);

        }

        public void IncreaseView(int id)
        {
            var model = _productRepositories.GetSingleById(id);

            if (model.ViewCount.HasValue)
            {
                model.ViewCount++;
            }
            else
            {
                model.ViewCount = 1;
            }
            _productRepositories.Update(model);
            _unitOfWork.Commit();
        }

        public Tag GetTag(string tagId)
        {
            return _tagRepository.GetSingleByCondition(k => k.ID == tagId);
        }
    }
}
