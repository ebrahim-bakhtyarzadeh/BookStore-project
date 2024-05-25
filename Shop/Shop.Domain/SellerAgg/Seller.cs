using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Domain.SellerAgg
{
    public class Seller : AggregateRoot
    {
        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
        public DateTime? LastUpdate { get; internal set; }
        public SellerStatus Status { get; private set; }
        public List<SellerInventory> Inventories { get; private set; }


        private Seller()
        {

        }
        public Seller(long userId, string shopName, string nationalCode, ISellerDomainService domainService)
        {
            Guard(shopName, nationalCode);

            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
            if (domainService.CheckSellerIsExist(this))
            {
                throw new InvalidDomainDataException("Information Is not Valid");
            }

        }

        public void ChangeStatus(SellerStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void Edit(string shopName, string nationalCode, ISellerDomainService domainService, SellerStatus status)
        {
            Guard(shopName, nationalCode);
            if (nationalCode != NationalCode)
            {
                if (domainService.NationalCodeIsExist(nationalCode))
                {
                    throw new InvalidDomainDataException("The national code belongs to someone else !");
                }
            }
            ShopName = shopName;
            NationalCode = nationalCode;
            ChangeStatus(status);
        }

        public void AddInventory(SellerInventory newInventory)
        {
            if (Inventories.Any(f => f.ProductId == newInventory.ProductId))
                throw new InvalidDomainDataException("new inventory is exist");
            Inventories.Add(newInventory);
        }

        public void EditInventory(long inventoryId, int count, int price, int? discountPercentage)
        {
            var currentInventory = Inventories.FirstOrDefault(o => o.Id == inventoryId);
            if (currentInventory == null)
                throw new NullOrEmptyDomainDataException("Product not found");

            //TODO Check Inventories
            currentInventory.Edit(count, price, discountPercentage);
        }

        //public void DeleteInventory(long inventoryId)
        //{
        //    var currentInventory = Inventories.FirstOrDefault(o => o.Id == inventoryId);
        //    if (currentInventory == null)
        //        throw new NullOrEmptyDomainDataException("inventory id not found ");
        //    Inventories.Remove(currentInventory);

        //}

        public void Guard(string shopName, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(shopName, nameof(shopName));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
            if (IranianNationalIdChecker.IsValid(nationalCode) == false)
                throw new InvalidDomainDataException("in sellerAgg national code is not Valid");


        }


    }
}
