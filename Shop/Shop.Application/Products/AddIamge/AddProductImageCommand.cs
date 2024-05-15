using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Products.AddIamge
{
    public record AddProductImageCommand(long productId, IFormFile ImageFile, int Sequence) : IBaseCommand;
}
