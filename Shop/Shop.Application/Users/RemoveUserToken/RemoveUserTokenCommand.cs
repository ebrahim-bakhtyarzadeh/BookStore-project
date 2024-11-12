using Common.Application;
using Shop.Domain.UserAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.RemoveUserToken;
public record  RemoveUserTokenCommand(long userId,long tokenId) :IBaseCommand;
public class RemoveUserTokenCommandHandler : IBaseCommandHandler<RemoveUserTokenCommand>
{

    private readonly IUserRepository _userRepository;

    public RemoveUserTokenCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResult> Handle(RemoveUserTokenCommand request, CancellationToken cancellationToken)
    {
        var user =await _userRepository.GetTracking(request.userId);
        if (user == null) 
            return  OperationResult.NotFound();


        user.RemoveToken(request.tokenId);
        await _userRepository.Save();
        return OperationResult.Success();
    }
}

