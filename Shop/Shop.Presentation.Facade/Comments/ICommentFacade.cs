using Common.Application;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Edit;
using Shop.Query.Comments.DTOs;

namespace Shop.Presentation.Facade.Comments;

public interface ICommentFacade
{
    //command
    Task<OperationResult> ChangeStatus(ChangeCommentStatusCommand command);
    Task<OperationResult> Edit(EditCommentCommand command);
    Task<OperationResult> Create(CreateCommentCommand command);

    //Queries

    Task<CommentDto?> GetCommentById(long id);
    Task<CommentFilterResult> GetCommentByFilter(CommentFilterParams Filter);
}
