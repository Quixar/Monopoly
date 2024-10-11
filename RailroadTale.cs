class RailroadTale : PropertyTale, IPurchasable
{
    public int maxRoad { get; private set; }
    public RailroadTale(string name, int price, int propertySellPrice) : base(name, price, propertySellPrice)
    {

    }

    public override void Draw()
    {

    }

    public void BuyTale(Player buyer)
    {
        throw new NotImplementedException();
    }

    public void SellTale(Player buyer, Player seller)
    {
        throw new NotImplementedException();
    }
}