class Tale
{
    public string Name { get; set; }
    public bool IsSold { get; set; }
    public double Price { get; private set; }
    public double RentPrice { get; private set; }
    List<House> houses;
    Hotel hotel;
    int maxHouses = 4;

    public Tale(string name, double price, double rentPrice)
    {
        houses = new List<House>();
        hotel = null;
        Name = name;
        Price = price;
        RentPrice = rentPrice;
        IsSold = false;
    }

    public void BuyHouse(Wallet wallet, House house)
    {
        if(houses.Count <= 4 
        && wallet.AmountMoney >= house.Price 
        && hotel == null)
        {
            houses.Add(new House());
        }
        else
        {

        }
    }

    public void BuyHotel(Wallet wallet)
    {
        if(houses.Count == maxHouses && wallet.AmountMoney >= hotel.Price)
        {
            wallet.AmountMoney -= hotel.Price;
            hotel = new Hotel();
            houses.Clear();
        }
        else
        {

        }
    }

    public void BuyTale(Wallet wallet)
    {
        if(!IsSold && wallet.AmountMoney >= Price)
        {
            wallet.AmountMoney -= Price;
            IsSold = true;
        }
        else
        {
            
        }
    }

    public double CalculateRent()
    {
        return 0;
    }
}