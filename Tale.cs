class Tale
{
    public string Name { get; set; }
    public bool IsSold { get; set; }
    public double Price { get; private set; }
    public double RentPrice { get; private set; }
    List<House> houses;
    int maxHouses = 3;

    public Tale(string name, double price, double rentPrice)
    {
        houses = new List<House>();
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
}