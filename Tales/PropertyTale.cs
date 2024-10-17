class PropertyTale : Tale, IPurchasable
{
    public int Price { get; set; }
    public int PropertySellPrice { get; set; }
    public Player owner;

    public PropertyTale(string name, int price) : base(name)
    {
        owner = null;
        Price = price;
        PropertySellPrice = price / 2;
    }

    public void BuyTale(Player player)
    {
        if (player.wallet.AmountMoney >= Price)
        {
            player.wallet.AmountMoney -= Price;
            owner = player;
        }
        else
        {
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
        }
    }

    public override void OnStep(Player player)
    {
    }
}
