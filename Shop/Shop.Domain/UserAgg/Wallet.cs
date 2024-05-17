using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.UserAgg;

public class Wallet : BaseEntity
{
    public Wallet(int price, string description, bool isFinally, WalletType type)
    {
        Guard(price);

        Price = price;
        Description = description;
        IsFinally = isFinally;
        if (isFinally)
        {
            FinallyDate = DateTime.Now;
        }
        Type = type;
    }
    //public long UserId { get; private set; }
    public int Price { get; private set; }
    public string Description { get; private set; }
    public bool IsFinally { get; private set; }
    public DateTime? FinallyDate { get; private set; }
    public WalletType Type { get; private set; }

    public void Finally(string refCode)
    {
        FinallyDate = DateTime.Now;
        IsFinally = true;
        Description += $"Tracking Code {refCode}";

    }
    public void Finally()
    {
        FinallyDate = DateTime.Now;
        IsFinally = true;
        Description += $"Tracking Code";

    }

    public void Guard(int price)
    {
        if (price < 500)
        {
            throw new InvalidDomainDataException("price is not valid");
        }
    }
}