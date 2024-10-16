class CommunityChestTale : EventTale
{
    List<Action<Player>> chestCards;
    Random random;
    public CommunityChestTale() : base("Chest")
    {
        random = new Random();
        InitCommunityCards();
    }

    void InitCommunityCards()
    {
        chestCards = new List<Action<Player>>
        {
            player => { player.wallet.AmountMoney += 200;},
            player => { player.wallet.AmountMoney -= 100;},
            player => { player.wallet.AmountMoney += 10;},
            player => { player.wallet.AmountMoney -= 50;},
            player => { player.wallet.AmountMoney += 100;},
            player => { player.MoveToStart();}
        };
    }

    public override void OnStep(Player player)
    {
        int cursorY = 16;
        ConsoleKeyInfo keyInfo;

        int cardIndex = random.Next(chestCards.Count);
        chestCards[cardIndex]?.Invoke(player);

        Console.SetCursorPosition(120, cursorY++);
        Console.WriteLine($"Player {player.Name} drew a Community Chest card:");

        Console.SetCursorPosition(120, cursorY++);
        if (cardIndex == 0)
        {
            Console.WriteLine($"Player {player.Name} received 200$.");
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine("Press any key to continue");
            keyInfo = Console.ReadKey(true);
        }
        else if (cardIndex == 1)
        {
            Console.WriteLine($"Player {player.Name} lost 100$.");
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine("Press any key to continue");
            keyInfo = Console.ReadKey(true);
        }  
        else if (cardIndex == 2)
        {
            Console.WriteLine($"Player {player.Name} received 10$.");
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine("Press any key to continue");
            keyInfo = Console.ReadKey(true);
        }
        else if (cardIndex == 3)
        {
            Console.WriteLine($"Player {player.Name} lost 50$.");
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine("Press any key to continue");
            keyInfo = Console.ReadKey(true);
        }
        else if (cardIndex == 4)
        {
            Console.WriteLine($"Player {player.Name} received 100$.");
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine("Press any key to continue");
            keyInfo = Console.ReadKey(true);
        }
        else if (cardIndex == 5)
        {
            Console.WriteLine($"Player {player.Name} moved to Start.");
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine("Press any key to continue");
            keyInfo = Console.ReadKey(true);
        }
        player.NextStep();
    }
}