class UtilityTale : PropertyTale, IPurchasable
{
    public int RentMultiplierSingle { get; set; }
    public int RentMultiplierBoth { get; set; }

    public UtilityTale(string name)
        : base(name, 150)
    {
        RentMultiplierSingle = 4;
        RentMultiplierBoth = 10;
    }

    public void BuyTale(Player buyer)
    {
        if (owner == null)
        {
            if (buyer.wallet.AmountMoney >= Price)
            {
                buyer.wallet.AmountMoney -= Price;
                owner = buyer;
            }
            else
            {
                Console.WriteLine($"{buyer.Name} не хватает денег для покупки {Name}.");
            }
        }
    }

    public void SellTale(Player buyer, Player seller)
    {
        if (owner != null)
        {
            if (buyer.wallet.AmountMoney >= PropertySellPrice)
            {
                buyer.wallet.AmountMoney -= PropertySellPrice;
                seller.wallet.AmountMoney += PropertySellPrice;
                owner = buyer;
            }
            else
            {
                Console.WriteLine($"{buyer.Name} не хватает денег для покупки {Name}.");
            }
        }
    }
}