class UtilityTale : PropertyTale, IPurchasable
{
    public int RentMultiplierSingle { get; set; }
    public int RentMultiplierBoth { get; set; }

    public UtilityTale(string name)
        : base(name, 150)
    {
        RentMultiplierSingle = 4;
        RentMultiplierBoth = 10;
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
            else
            {
                Console.WriteLine($"{buyer.Name} не хватает денег для покупки {Name}.");
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
            else
            {
                Console.WriteLine($"{buyer.Name} не хватает денег для покупки {Name}.");
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
            player.PayRentForUtilityTale();
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine($"Player {player.Name} paid player {owner.Name} rent {player.rentToPay} for {Name} tale");
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine("Press any key to continue");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        }

        player.NextStep();
    }
}