using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Edit;
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

        [HttpGet]
        public async Task<ApiResult<CommentFilterResult>> GetCommentByFilter([FromQuery] CommentFilterParams filter)
        {
            var result = await _commentFacade.GetCommentByFilter(filter);
            return QueryResult(result);
        }


        [HttpGet("{commentId}")]
        public async Task<ApiResult<CommentDto?>> GetCommentById(long commentId)
        {
            var result = await _commentFacade.GetCommentById(commentId);
            return QueryResult(result);
        }


        [HttpPost]
        public async Task<ApiResult> GetCommentByFilter(CreateCommentCommand command)
        {
            var result = await _commentFacade.Create(command);
            return CommandResult(result);
        }
        [HttpPut]
        public async Task<ApiResult> EditComment(EditCommentCommand command)
        {
            var result = await _commentFacade.Edit(command);
            return CommandResult(result);
        }

        [HttpPut("ChangeStatus")]
        public async Task<ApiResult> ChangeCommentStatus(ChangeCommentStatusCommand command)
        {
            var result = await _commentFacade.ChangeStatus(command);
            return CommandResult(result);

        }
    }
}
