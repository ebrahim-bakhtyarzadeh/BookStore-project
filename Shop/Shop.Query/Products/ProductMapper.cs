using Microsoft.EntityFrameworkCore;
using Shop.Domain.ProductAgg;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products
{
    public static class ProductMapper
    {
        public static ProductDto? Map(this Product? product)
        {
            if (product == null)
                return null;
            return new()
            {



                Id = product.Id,
                CreationDate = product.CreationDate,
                Description = product.Description,
                ImageName = product.ImageName,
                Slug = product.Slug,
                Title = product.Title,
                SeoData = product.SeoData,
                Specifications = product.Specifications.Select(s => new ProductSpecificationDto()
                {
                    Value = s.Value,
                    Key = s.Key
                }).ToList(),
                Images = product.Images.Select(s => new ProductImageDto()
                {
                    Id = s.Id,
                    CreationDate = s.CreationDate,
                    ImageName = s.ImageName,
                    ProductId = s.ProductId,
                    Sequence = s.Sequence
                }).ToList(),

                Category = new ProductCategoryDto()
                {
                    Id = product.CategoryId
                },
                SubCategory = new()
                {
                    Id = product.SubCategoryId
                },
                SecondarySubCategory = product.SecondarySubCategoryId != null ? new()
                {
                    Id = (long)product.SecondarySubCategoryId
                } : null,
            };
        }
        public static ProductFilterData? MapLlistData(this Product? product)
        {
            if (product == null)
                return null;
            return new()
            {
                Id = product.Id,
                CreationDate = product.CreationDate,
                ImageName = product.ImageName,
                Slug = product.Slug,
                Title = product.Title,
            };
        }

        public static async Task SetCategories(this ProductDto product, ShopContext _context)
        {
            var category = await _context.Categories
                .Where(c => c.Id == product.Category.Id)
                .Select(s => new ProductCategoryDto()
                {
                    Id = s.Id,
                    Slug = s.Slug,
                    Title = s.Title,
                    SeoData = s.SeoData,
                    ParentId = s.ParentId,
                })
                .FirstOrDefaultAsync();
            if (product.SecondarySubCategory != null)
            {

                var subCategory = await _context.Categories.Where(c => c.Id == product.SubCategory.Id)
                    .Select(s => new ProductCategoryDto()
                    {
                        Id = s.Id,
                        Slug = s.Slug,
                        Title = s.Title,
                        SeoData = s.SeoData,
                        ParentId = s.ParentId,
                    })
                    .FirstOrDefaultAsync(c => c.Id == product.SecondarySubCategory.Id);
                if (subCategory != null)
                    product.SubCategory = subCategory;
            }


            if (product.SecondarySubCategory != null)
            {
                var secondarySubCategory = await _context.Categories
                    .Where(c => c.Id == product.Category.Id)
                    .Select(s => new ProductCategoryDto()
                    {
                        Id = s.Id,
                        Slug = s.Slug,
                        Title = s.Title,
                        SeoData = s.SeoData,
                        ParentId = s.ParentId,
                    })
                    .FirstOrDefaultAsync(c => c.Id == product.SecondarySubCategory.Id);
                if (secondarySubCategory != null)
                    product.SecondarySubCategory = secondarySubCategory;
            }



            if (category != null)
                product.Category = category;







        }
    }
}
