class ChanceTale : EventTale
{
    List<Action<Player>> chanceCards;
    Random random;

    public ChanceTale() : base("Chance")
    {
        random = new Random();
        InitChanceCards();
    }

    void InitChanceCards()
    {
        chanceCards = new List<Action<Player>>
        {
            player => { player.wallet.AmountMoney += 100;},
            player => { player.wallet.AmountMoney -= 50;},
            player => { player.wallet.AmountMoney += 200;},
            player => { player.MoveToStart();},
            player => { player.wallet.AmountMoney -= 150;},
            player => { player.wallet.AmountMoney += 50;},
            player => { player.wallet.AmountMoney -= 100;},
            player => { player.currentPosition -= 3;},
            player => { player.currentPosition += 5;}
        };
    }

    public override void OnStep(Player player)
    {
        int cursorY = 16;
        ConsoleKeyInfo keyInfo;

        int cardIndex = random.Next(chanceCards.Count);
        chanceCards[cardIndex]?.Invoke(player);

        Console.SetCursorPosition(120, cursorY++);
        Console.WriteLine($"Player {player.Name} drew a Chance card:");

        Console.SetCursorPosition(120, cursorY++);
        
        if (cardIndex == 0)
        {
            Console.WriteLine($"Player {player.Name} received 100$.");
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine("Press any key to continue");
            keyInfo = Console.ReadKey(true);
        }
        else if (cardIndex == 1)
        {
            Console.WriteLine($"Player {player.Name} lost 50$.");
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine("Press any key to continue");
            keyInfo = Console.ReadKey(true);
        }
        else if (cardIndex == 2)
        {
            Console.WriteLine($"Player {player.Name} received 200$.");
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine("Press any key to continue");
            keyInfo = Console.ReadKey(true);
        }
        else if (cardIndex == 3)
        {
            Console.WriteLine($"Player {player.Name} moved to Start.");
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine("Press any key to continue");
            keyInfo = Console.ReadKey(true);
        }
        else if (cardIndex == 4)
        {
            Console.WriteLine($"Player {player.Name} lost 150$.");
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine("Press any key to continue");
            keyInfo = Console.ReadKey(true);
        }
        else if (cardIndex == 5)
        {
            Console.WriteLine($"Player {player.Name} received 50$.");
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine("Press any key to continue");
            keyInfo = Console.ReadKey(true);
        }
        else if (cardIndex == 6)
        {
            Console.WriteLine($"Player {player.Name} lost 100$.");
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine("Press any key to continue");
            keyInfo = Console.ReadKey(true);
        }
        else if (cardIndex == 7)
        {
            Console.WriteLine($"Player {player.Name} moved back 3 spaces.");
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine("Press any key to continue");
            keyInfo = Console.ReadKey(true);
        }
        else if (cardIndex == 8)
        {
            Console.WriteLine($"Player {player.Name} moved forward 5 spaces.");
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine("Press any key to continue");
            keyInfo = Console.ReadKey(true);
        }
        player.NextStep();
    }
}