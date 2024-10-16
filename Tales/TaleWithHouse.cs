class TaleWithHouse : PropertyTale, IPurchasable
{
    public List<House> houses;
    public Hotel hotel;
    public int Rent1 { get; set; }
    public int Rent2 { get; set;}
    public int Rent3 { get; set;}
    public int Rent4 { get; set;}
    public int Rent5 { get; set;}
    public int Rent6 { get; set;}
    readonly int maxHouses = 4;

    public TaleWithHouse(string name, int price, int rent1, int rent2, int rent3, int rent4, int rent5, int rent6, int housePrice) 
    : base(name, price)
    {
        PropertySellPrice = price / 2;
        Rent1 = rent1;
        Rent2 = rent2;
        Rent3 = rent3;
        Rent4 = rent4;
        Rent5 = rent5;
        Rent6 = rent6;
        houses = new List<House>(housePrice);
        hotel = null;
        
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

    public void BuyHouse(Player buyer)
    {
        if (buyer.wallet.AmountMoney >= Price)
        {
            buyer.wallet.AmountMoney -= Price;
            houses.Add(new House());
        }
    }

    public void BuyHotel(Player buyer)
    {
        if (houses.Count == maxHouses && hotel == null)
        {
            if (buyer.wallet.AmountMoney >= Price)
            {
                buyer.wallet.AmountMoney -= Price;
                hotel = new Hotel();
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

    public override void OnStep(Player player)
    {
        if (owner == null)
        {
            Console.WriteLine($"Player {player.Name}, do you want to buy {Name} for {Price}? (Y/N)");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Y)
            {
                if (player.wallet.AmountMoney >= Price)
                {
                    BuyTale(player);
                }
                else
                {
                }
            }
            else if (keyInfo.Key == ConsoleKey.N)
            {
            }
        }
        else if (owner != null && owner != player)
        {
            player.PayRentForTaleWithHouse();
        }
        else if (player == owner)
        {
            Console.WriteLine($"Player {player.Name}, do you want to buy a house on {Name}? (Y/N)");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Y)
            {
                BuyHouse(player);
                Console.WriteLine($"{player.Name} bought a house on {Name}.");
            }
            else if (keyInfo.Key == ConsoleKey.N)
            {
                Console.WriteLine($"{player.Name} decided not to buy a house on {Name}.");
            }
        }

        player.NextStep();
    }
}