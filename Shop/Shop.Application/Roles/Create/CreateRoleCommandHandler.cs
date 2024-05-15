using Common.Application;
using Shop.Domain.RoleAgg;

namespace Shop.Application.Roles.Create;

internal class CreateRoleCommandHandler : IBaseCommandHandler<CreateRoleCommand>
{
    private readonly IRoleRepository _roleRepository;

    public CreateRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var permissions = new List<RolePermission>();
        request.Permissions.ToList().ForEach(f =>
            permissions.Add(new RolePermission(f)));
        var role = new Role(request.Title, permissions);
        await _roleRepository.AddAsync(role);
        await _roleRepository.Save();
        return OperationResult.Success();
    }
}