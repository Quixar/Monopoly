class RailroadTale : PropertyTale, IPurchasable
{
    public int maxRoad { get; private set; }
    public RailroadTale(string name, int price, int propertySellPrice) : base(name, price, propertySellPrice)
    {

    }

    public override void Draw()
    {

    }

    public void BuyTale(Wallet buyerWallet)
    {
        throw new NotImplementedException();
    }

    public void SellTale(Wallet buyerWallet, Wallet sellerWallet)
    {
        throw new NotImplementedException();
    }
}