class TaleWithHouse : PropertyTale, IPurchasable
{
    List<House> houses;
    Hotel hotel;
    readonly int maxHouses = 4;

    public TaleWithHouse(string name, int price, int propertySellPrice) 
    : base(name, price, propertySellPrice)
    {

        houses = new List<House>();
        hotel = null;
        
    }

    public void BuyTale(Player buyer)
    {
        if(owner == null)
        {
            if(buyer.wallet.AmountMoney >= Price)
            {
                buyer.wallet.AmountMoney -= Price;
                owner = buyer;
                IsSold = true;
            }
        }
    }

    public void BuyHouse(Player buyer)
    {
        if(buyer.wallet.AmountMoney >= Price)
        {
            buyer.wallet.AmountMoney -= Price;
            houses.Add(new House());
        }
    }

    public void BuyHotel(Player buyer)
    {
        if(houses.Count == maxHouses && hotel == null)
        {
            if(buyer.wallet.AmountMoney >= Price)
            {
                buyer.wallet.AmountMoney -= Price;
                hotel = new Hotel();
            }
        }
    }

    public void SellTale(Player buyer, Player seller)
    {
        if(owner != null)
        {
            if(buyer.wallet.AmountMoney >= PropertySellPrice)
            {
                buyer.wallet.AmountMoney -= PropertySellPrice;
                seller.wallet.AmountMoney += PropertySellPrice;
                owner = buyer;
            }
        }
    }

    public override void OnStep(Player player)
    {
        // To Do -- плейеру предоставляется возможность покупки/продажи
    }
}