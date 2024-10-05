class Tale
{
    public string Name { get; set; }
    public bool IsSold { get; set; }
    public double Price { get; private set; }
    public double RentPrice { get; private set; }
    List<House> houses;
    List<Hotel> hotels;
    int maxHouses = 4;

    public Tale(string name, double price, double rentPrice)
    {
        houses = new List<House>();
        hotels = new List<Hotel>();
        Name = name;
        Price = price;
        RentPrice = rentPrice;
        IsSold = false;
    }

    public void BuyHouse(Wallet wallet, House house)
    {
        if(maxHouses <= 3)
        {
            if(wallet.AmountMoney > house.Price)
            {
                houses.Add(new House());
            }
            else
            {

            }
        }
        else
        {

        }
    }

    public void BuyHotel(Wallet wallet, Hotel hotel)
    {
        if(houses.Count == maxHouses && wallet.AmountMoney > hotel.Price)
        {
            wallet.AmountMoney -= hotel.Price;
            hotels.Add(new Hotel());
            houses.Clear();
        }
        else
        {

        }
    }

    public void BuyTale(Wallet wallet)
    {
        if(!IsSold && wallet.AmountMoney > Price)
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