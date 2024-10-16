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
        int cursorY = 16;

        if (owner == null)
        {
            Console.SetCursorPosition(120, cursorY++);
            Console.WriteLine($"Player {player.Name}, do you want to buy {Name} for {Price}? (Y/N)");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Y)
            {
                if (player.wallet.AmountMoney >= Price)
                {
                    BuyTale(player);
                    Console.SetCursorPosition(120, cursorY++);
                    Console.WriteLine($"{player.Name} bought {Name} for {Price}.");
                    Console.SetCursorPosition(120, cursorY++);
                    System.Console.WriteLine("Press any key to continue");
                    keyInfo = Console.ReadKey(true);

                }
                else
                {
                    Console.SetCursorPosition(120, cursorY++);
                    Console.WriteLine($"{player.Name} doesn't have enough money to buy {Name}.");
                    Console.SetCursorPosition(120, cursorY++);
                    System.Console.WriteLine("Press any key to continue");
                    keyInfo = Console.ReadKey(true);
                }
            }
            else
            {
                Console.SetCursorPosition(120, cursorY++);
                Console.WriteLine($"{player.Name} decided not to buy {Name}.");
                Console.SetCursorPosition(120, cursorY++);
                System.Console.WriteLine("Press any key to continue");
                keyInfo = Console.ReadKey(true);
            }
        }
        else if (owner != null && owner != player)
        {
            Console.SetCursorPosition(120, cursorY++);
            player.PayRentForRailroadTale();
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine($"Player {player.Name} paid player {owner.Name} rent {player.rentToPay} for {Name} tale");
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine("Press any key to continue");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        }
        
        player.NextStep();
    }
}