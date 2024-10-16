class RailroadTale : PropertyTale, IPurchasable
{
    readonly int maxRoad = 4;
    public int Rent1 { get; set; }
    public int Rent2 { get; set; }
    public int Rent3 { get; set; }
    public int Rent4 { get; set; }
    public RailroadTale(string name, int price, int rent1, int rent2, int rent3,int rent4) : base(name, price)
    {
        PropertySellPrice = price / 2;
        Rent1 = rent1;
        Rent2 = rent2;
        Rent3 = rent3;
        Rent4 = rent4;
    }
    public RailroadTale() : base("Railroad", 200)
    {
        PropertySellPrice = 100;
        Rent1 = 25;
        Rent2 = 50;
        Rent3 = 100;
        Rent4 = 200;
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
                    Console.WriteLine($"{player.Name} bought {Name} for {Price}.");
                }
                else
                {
                    Console.WriteLine($"{player.Name} doesn't have enough money to buy {Name}.");
                }
            }
            else
            {
                Console.WriteLine($"{player.Name} decided not to buy {Name}.");
            }
        }
        else if (owner != null && owner != player)
        {
            player.PayRentForRailroadTale();
        }
        else if (player == owner)
        {
            Console.WriteLine($"Player {player.Name} already owns {Name}.");
        }
        player.NextStep();
    }
}