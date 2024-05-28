using Common.Application;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Edit;
using Shop.Query.Comments.DTOs;

namespace Shop.Presentation.Facade.Comments;

internal interface ICommentFacade
{
    //command
    Task<OperationResult> ChangeStatus(ChangeCommentStatusCommand command);
    Task<OperationResult> Edit(EditCommentCommand command);
    Task<OperationResult> Create(CreateCommentCommand command);

    //Queries

    Task<CommentDto?> GetById(int id);
    Task<CommentFilterResult> GetByFilter(CommentFilterParams Filter);
}