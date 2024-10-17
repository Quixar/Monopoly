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
            else
            {
                System.Console.WriteLine($"Player {buyer.Name} doenst have enough money to buy {Name}");
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
        else
        {
            System.Console.WriteLine($"Player {buyer.Name} doenst have enough money to buy house");
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
            else
            {
                System.Console.WriteLine($"Plyaer {buyer.Name} doesnt have enough money to buy hotel");
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
                BuyTale(player);
                Console.SetCursorPosition(120, cursorY++);
                System.Console.WriteLine($"Player {player.Name} decided to buy {Name} tale");
                Console.SetCursorPosition(120, cursorY++);
                System.Console.WriteLine("Press any key to continue");
                keyInfo = Console.ReadKey(true);
            }
            else if (keyInfo.Key == ConsoleKey.N)
            {
                Console.SetCursorPosition(120, cursorY++);
                System.Console.WriteLine($"Player {player.Name} decided not to buy {Name} tale");
                Console.SetCursorPosition(120, cursorY++);
                System.Console.WriteLine("Press any key to continue");
                keyInfo = Console.ReadKey(true);
            }
        }
        else if (owner != null && owner != player)
        {
            player.PayRentForTaleWithHouse();
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine($"Player {player.Name} paid player {owner.Name} rent {player.rentToPay} for {Name} tale");
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine("Press any key to continue");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        }
        else if (player == owner)
        {
            if (houses.Count < maxHouses)
            {
                Console.SetCursorPosition(120, cursorY++);
                Console.WriteLine($"Player {player.Name}, do you want to buy a house on {Name} tale? (Y/N)");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Y)
                {
                    BuyHouse(player);
                    Console.SetCursorPosition(120, cursorY++);
                    Console.WriteLine($"{player.Name} bought a house on {Name}.");
                    Console.SetCursorPosition(120, cursorY++);
                    System.Console.WriteLine("Press any key to continue");
                    keyInfo = Console.ReadKey(true);
                }
                else if (keyInfo.Key == ConsoleKey.N)
                {
                    Console.SetCursorPosition(120, cursorY++);
                    Console.WriteLine($"{player.Name} decided not to buy a house on {Name}.");
                    Console.SetCursorPosition(120, cursorY++);
                    System.Console.WriteLine("Press any key to continue");
                    keyInfo = Console.ReadKey(true);
                }
            }
            else if (houses.Count == maxHouses && hotel == null)
            {
                Console.SetCursorPosition(120, cursorY++);
                Console.WriteLine($"Player {player.Name}, do you want to buy a hotel on {Name}? (Y/N)");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Y)
                {
                    BuyHotel(player);
                    Console.SetCursorPosition(120, cursorY++);
                    Console.WriteLine($"{player.Name} bought a hotel on {Name}.");
                    Console.SetCursorPosition(120, cursorY++);
                    System.Console.WriteLine("Press any key to continue");
                    keyInfo = Console.ReadKey(true);
                }

                else if (keyInfo.Key == ConsoleKey.N)
                {
                    Console.SetCursorPosition(120, cursorY++);
                    Console.WriteLine($"{player.Name} decided not to buy a hotel on {Name}.");
                    Console.SetCursorPosition(120, cursorY++);
                    System.Console.WriteLine("Press any key to continue");
                    keyInfo = Console.ReadKey(true);
                }
            }
        }
        player.NextStep();
    }
}