class TaleWithHouse : PropertyTale, IPurchasable
{
    List<House> houses;
    Hotel hotel;
    readonly int maxHouses = 4;

    public TaleWithHouse(string name, int price, int propertySellPrice) 
    : base(name, price, propertySellPrice)
    {
        
    }
    public void BuyTale(Wallet buyerWallet)
    {

    }

    public void SellTale(Wallet buyerWallet, Wallet sellerWallet)
    {

    }

    public override void OnStep(Player player)
    {
        // To Do -- плейеру предоставляется возможность покупки/продажи
    }
}