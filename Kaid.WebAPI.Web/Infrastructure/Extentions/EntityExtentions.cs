using Kaid.WebAPI.Model.Models;
using Kaid.WebAPI.Web.Models.ViewModels;

namespace Kaid.WebAPI.Web.Infrastructure.Extentions
{
    public static class EntityExtentions
    {
        public static void UpdatePostCategory(this PostCategory model, PostCategoryViewModel viewModel)
        {
            model.ID = viewModel.ID;
            model.Name = viewModel.Name;
            model.Description = viewModel.Description;
            model.Alias = viewModel.Alias;

            model.ParentID = viewModel.ParentID;
            model.DisplayOrder = viewModel.DisplayOrder;
            model.Image = viewModel.Image;
            model.HomeFlag = model.HomeFlag;

            model.CreateBy = viewModel.CreateBy;
            model.CreateDate = viewModel.CreateDate;
            model.UpdateBy = viewModel.UpdateBy;
            model.UpdateDate = viewModel.UpdateDate;
            model.MetaDescription = viewModel.MetaDescription;
            model.MetaKeyword = viewModel.MetaKeyword;
            model.Status = viewModel.Status;
        }

        public static void UpdatePost(this Post model, PostViewModel viewModel)
        {
            model.ID = viewModel.ID;
            model.Name = viewModel.Name;
            model.Description = viewModel.Description;
            model.Alias = viewModel.Alias;

            model.CategoryID = viewModel.CategoryID;
            model.Content = viewModel.Content;
            model.ViewCount = viewModel.ViewCount;
            model.Image = viewModel.Image;
            model.HomeFlag = viewModel.HomeFlag;

            model.CreateBy = viewModel.CreateBy;
            model.CreateDate = viewModel.CreateDate;
            model.UpdateBy = viewModel.UpdateBy;
            model.UpdateDate = viewModel.UpdateDate;
            model.MetaDescription = viewModel.MetaDescription;
            model.MetaKeyword = viewModel.MetaKeyword;
            model.Status = viewModel.Status;
        }
        public static void UpdateProductCategory(this ProductCategory model, ProductCategoryViewModel viewModel)
        {
          model.ID = viewModel.ID;
          model.Name = viewModel.Name;
          model.Description = viewModel.Description;
          model.Alias = viewModel.Alias;
        
          model.ParentID = viewModel.ParentID;
          model.DisplayOrder = viewModel.DisplayOrder;
          model.Image = viewModel.Image;
          model.HomeFlag = viewModel.HomeFlag;
         
          model.CreateBy = viewModel.CreateBy;
          model.CreateDate = viewModel.CreateDate;
          model.UpdateBy = viewModel.UpdateBy;
          model.UpdateDate = viewModel.UpdateDate;
          model.MetaDescription = viewModel.MetaDescription;
          model.MetaKeyword = viewModel.MetaKeyword;
          model.Status = viewModel.Status;
        }

        public static void UpdateProduct(this Product model, ProductViewModel viewModel)
        {
            model.ID = viewModel.ID;
            model.Name = viewModel.Name;
            model.Description = viewModel.Description;
            model.Alias = viewModel.Alias;

            model.Price = viewModel.Price;
            model.PromotionPrice = viewModel.PromotionPrice;
            model.Warranty = viewModel.Warranty;

            model.CategoryID = viewModel.CategoryID;
            model.MoreImages = viewModel.MoreImages;
            model.Image = viewModel.Image;
            model.HomeFlag = viewModel.HomeFlag;

            model.CreateBy = viewModel.CreateBy;
            model.CreateDate = viewModel.CreateDate;

            model.UpdateBy = viewModel.UpdateBy;
            model.UpdateDate = viewModel.UpdateDate;

            model.MetaDescription = viewModel.MetaDescription;
            model.MetaKeyword = viewModel.MetaKeyword;
            model.Content = viewModel.Content;

            model.Status = viewModel.Status;
            model.HomeFlag = viewModel.HomeFlag;
            model.HotFlag = viewModel.HotFlag;
            model.ViewCount = viewModel.ViewCount;
            model.Tags = viewModel.Tags;
            model.Quanlity = viewModel.Quanlity;
        }
    }
}