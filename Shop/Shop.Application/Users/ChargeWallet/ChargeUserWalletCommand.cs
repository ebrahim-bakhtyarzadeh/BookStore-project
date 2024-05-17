using Common.Application;
using Common.Application.Validation;
using FluentValidation;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.ChargeWallet
{
    public class ChargeUserWalletCommand : IBaseCommand
    {
        public long UserId { get; private set; }
        public int Price { get; private set; }
        public string Description { get; private set; }
        public bool IsFinally { get; private set; }

        public WalletType Type { get; private set; }

        public ChargeUserWalletCommand(long userId, int price, string description, bool isFinally, WalletType type)
        {
            UserId = userId;
            Price = price;
            Description = description;
            IsFinally = isFinally;
            Type = type;
        }
    }
    public class ChargeUserWalletCommandHandler : IBaseCommandHandler<ChargeUserWalletCommand>
    {
        private readonly IUserRepository _userRepository;

        public ChargeUserWalletCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult> Handle(ChargeUserWalletCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTracking(request.UserId);
            if (user == null)
            {
                return OperationResult.NotFound();
            }
            var wallet = new Wallet(request.Price, request.Description, request.IsFinally, request.Type);

            user.ChargeWallet(wallet);

            await _userRepository.Save();
            return OperationResult.Success();

        }
    }
    public class ChargeUserWalletCommandValidator : AbstractValidator<ChargeUserWalletCommand>
    {
        public ChargeUserWalletCommandValidator()
        {
            RuleFor(r => r.Description)
                .NotEmpty().WithMessage(ValidationMessages.required("Description"));

            RuleFor(r => r.Price)
                .GreaterThanOrEqualTo(1000).WithMessage(ValidationMessages.required("Description"));


        }
    }
}
