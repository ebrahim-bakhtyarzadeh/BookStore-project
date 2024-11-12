using AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Security;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Domain.RoleAgg.Enums;
using Shop.Presentation.Facade.Categories;
using Shop.Query.Categories.DTOs;
using System.Net;

namespace Shop.Api.Controllers
{
    [PermissionChecker(Permission.Manage_Category)]
    public class CategoryController : ApiController
    {

        private readonly ICategoryFacade _categoryFacade;

        public CategoryController(ICategoryFacade categoryFacade)
        {
            _categoryFacade = categoryFacade;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ApiResult<List<CategoryDto>>> GetCategories()
        {
            var result = await _categoryFacade.GetAllCategories();
            return QueryResult(result);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ApiResult<CategoryDto>> GetCategoryById(long id)
        {
            var result = await _categoryFacade.GetCategoryById(id);
            return QueryResult(result);
        }

        [HttpGet("GetChilds/{parentId}")]
        public async Task<ApiResult<List<ChildCategoryDto>>> GetChilds(long parentId)
        {
            var result = await _categoryFacade.GetAllCategoriesByParentId(parentId);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult<long>> AddCategory([FromBody]CreateCategoryCommand command)
        {
            var data = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .SelectMany(x => x.Value.Errors.Select(error => new { Field = x.Key, Error = error.ErrorMessage }))
                .ToList();
            var result = await _categoryFacade.Create(command);
            var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);
            return CommandResult(result, HttpStatusCode.Created, url);
        }
        [HttpPost("AddChild")]
        public async Task<ApiResult<long>> AddChild(AddChildCategoryCommand command)
        {
            var result = await _categoryFacade.AddChild(command);
            var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);

            return CommandResult(result, HttpStatusCode.Created, url);
        }

        [HttpPut]
        public async Task<ApiResult> EditCategory(EditCategoryCommand command)
        {
            var result = await _categoryFacade.Edit(command);
            return CommandResult(result);
        }

        [HttpDelete("{categoryId}")]
        public async Task<ApiResult> RemoveCategory(long categoryId)
        {
            var result = await _categoryFacade.Remove(categoryId);
            return CommandResult(result);
        }
    }
}
