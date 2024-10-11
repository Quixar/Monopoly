class RailroadTale : PropertyTale, IPurchasable
{
    public int maxRoad { get; private set; }
    public RailroadTale(string name, int price, int propertySellPrice) : base(name, price, propertySellPrice)
    {
        maxRoad = 4;
    }

    public override void Draw()
    {

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
}