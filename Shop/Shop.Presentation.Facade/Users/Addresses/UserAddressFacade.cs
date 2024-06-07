using Common.Application;
using MediatR;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;
using Shop.Query.Users.Addresses.DTOs;
using Shop.Query.Users.Addresses.GetById;
using Shop.Query.Users.Addresses.GetList;

namespace Shop.Presentation.Facade.Users.Addresses
{
    internal class UserAddressFacade : IUserAddressFacade
    {
        private readonly IMediator _mediator;

        public UserAddressFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddAddress(AddUserAddressCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditAddress(EditUserAddressCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command)
        {
            return await _mediator.Send(command);

        }


        public async Task<AddressDto?> GetAddressById(long id)
        {
            return await _mediator.Send(new GetUserAddressByIdQuery(id));

        }

        public async Task<List<AddressDto>> GetListOfAddresses(long UserId)
        {
            return await _mediator.Send(new GetUserAddressesListQuery(UserId));

        }
    }
}