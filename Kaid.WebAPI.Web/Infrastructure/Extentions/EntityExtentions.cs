using Kaid.WebAPI.Model.Models;
using Kaid.WebAPI.Web.Models.ViewModels;

namespace Kaid.WebAPI.Web.Infrastructure.Extentions
{
    public static class EntityExtentions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryViewModel)
        {
            postCategory.ID = postCategoryViewModel.ID;
            postCategory.Name = postCategoryViewModel.Name;
            postCategory.Description = postCategoryViewModel.Description;
            postCategory.Alias = postCategoryViewModel.Alias;

            postCategory.ParentID = postCategoryViewModel.ParentID;
            postCategory.DisplayOrder = postCategoryViewModel.DisplayOrder;
            postCategory.Image = postCategoryViewModel.Image;
            postCategory.HomeFlag = postCategory.HomeFlag;

            postCategory.CreateBy = postCategoryViewModel.CreateBy;
            postCategory.CreateDate = postCategoryViewModel.CreateDate;
            postCategory.UpdateBy = postCategoryViewModel.UpdateBy;
            postCategory.UpdateDate = postCategoryViewModel.UpdateDate;
            postCategory.MetaDescription = postCategoryViewModel.MetaDescription;
            postCategory.MetaKeyword = postCategoryViewModel.MetaKeyword;
            postCategory.Status = postCategoryViewModel.Status;
        }

        public static void UpdatePost(this Post post, PostViewModel postViewModel)
        {
            post.ID = postViewModel.ID;
            post.Name = postViewModel.Name;
            post.Description = postViewModel.Description;
            post.Alias = postViewModel.Alias;

            post.CategoryID = postViewModel.CategoryID;
            post.Content = postViewModel.Content;
            post.ViewCount = postViewModel.ViewCount;
            post.Image = postViewModel.Image;
            post.HomeFlag = postViewModel.HomeFlag;

            post.CreateBy = postViewModel.CreateBy;
            post.CreateDate = postViewModel.CreateDate;
            post.UpdateBy = postViewModel.UpdateBy;
            post.UpdateDate = postViewModel.UpdateDate;
            post.MetaDescription = postViewModel.MetaDescription;
            post.MetaKeyword = postViewModel.MetaKeyword;
            post.Status = postViewModel.Status;
        }
    }
}