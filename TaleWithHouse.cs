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

    public TaleWithHouse(string name, int price, int rent1, int rent2, int rent3, int rent4, int rent5, int rent6, int propertySellPrice) 
    : base(name, price, propertySellPrice)
    {
        Rent1 = rent1;
        Rent2 = rent2;
        Rent3 = rent3;
        Rent4 = rent4;
        Rent5 = rent5;
        Rent6 = rent6;
        houses = new List<House>();
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
        string? choice;
        if (owner == null)
        {
            System.Console.WriteLine($"Do you want to buy {Name} tale? 1 - Yes | 2 - No");
            choice = Console.ReadLine();
            if (choice == "1")
            {
                BuyTale(player);
                player.NextStep();
            }
            else
            {
                player.NextStep();
            }
        }
        else if (owner != null && owner != player)
        {
            player.PayRentForTaleWithHouse();
            player.NextStep();
        }
        else if (player == owner)
        {
            System.Console.WriteLine("Do you want to buy a house for your tale? 1 - Yes | 2 - No");
            choice = Console.ReadLine();
            if (choice == "1")
            {
                BuyHouse(player);
                player.NextStep();
            }
            else if (choice == "2")
            {
                player.NextStep();
            }
        }
    }
}