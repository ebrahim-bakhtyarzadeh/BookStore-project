using Common.Application;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Presentation.Facade.Categories;
using Shop.Query.Categories.DTOs;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryFacade _categoryFacade;

        public CategoryController(ICategoryFacade categoryFacade)
        {
            _categoryFacade = categoryFacade;
        }


        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            var result = await _categoryFacade.GetAllCategories();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(long id)
        {
            var result = await _categoryFacade.GetCategoryById(id);
            return Ok(result);
        }

        [HttpGet("GetChilds/{parentId}")]
        public async Task<ActionResult<ChildCategoryDto>> GetChilds(long parentId)
        {
            var result = await _categoryFacade.GetAllCategoriesByParentId(parentId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<OperationResult>> AddCategory(CreateCategoryCommand command)
        {
            var result = await _categoryFacade.Create(command);
            if (result.Status == OperationResultStatus.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }
        [HttpPost("AddChild")]
        public async Task<ActionResult<OperationResult>> AddChild(AddChildCategoryCommand command)
        {
            var result = await _categoryFacade.AddChild(command);
            if (result.Status == OperationResultStatus.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }

        [HttpPut]
        public async Task<ActionResult<OperationResult>> EditCategory(EditCategoryCommand command)
        {
            var result = await _categoryFacade.Edit(command);
            if (result.Status == OperationResultStatus.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> RemoveCategory(long categoryId)
        {
            var result = await _categoryFacade.Remove(categoryId);
            if (result.Status == OperationResultStatus.Success)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }
    }
}
