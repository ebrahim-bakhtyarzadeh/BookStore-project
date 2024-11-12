using AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Security;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Edit;
using Shop.Domain.RoleAgg.Enums;
using Shop.Presentation.Facade.Comments;
using Shop.Query.Comments.DTOs;

namespace Shop.Api.Controllers
{
  
    public class CommentController : ApiController
    {
        private ICommentFacade _commentFacade;

        public CommentController(ICommentFacade commentFacade)
        {
            _commentFacade = commentFacade;
        }
        [PermissionChecker(Permission.Manage_Comment)]
        [HttpGet]
        public async Task<ApiResult<CommentFilterResult>> GetCommentByFilter([FromQuery] CommentFilterParams filter)
        {
            var result = await _commentFacade.GetCommentByFilter(filter);
            return QueryResult(result);
        }

        [PermissionChecker(Permission.Manage_Comment)]
        [HttpGet("{commentId}")]
        public async Task<ApiResult<CommentDto?>> GetCommentById(long commentId)
        {
            var result = await _commentFacade.GetCommentById(commentId);
            return QueryResult(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<ApiResult> CreateComment(CreateCommentCommand command)
        {
            var result = await _commentFacade.Create(command);
            return CommandResult(result);
        }
        [Authorize]
        [HttpPut]
        public async Task<ApiResult> EditComment(EditCommentCommand command)
        {
            var result = await _commentFacade.Edit(command);
            return CommandResult(result);
        }
        [PermissionChecker(Permission.Manage_Comment)]
        [HttpPut("ChangeStatus")]
        public async Task<ApiResult> ChangeCommentStatus(ChangeCommentStatusCommand command)
        {
            var result = await _commentFacade.ChangeStatus(command);
            return CommandResult(result);

        }
    }
}
