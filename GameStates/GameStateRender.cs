class GameStateRenderer
{
    public void RenderMap(Game game)
    {
        Console.Clear();
        int line = 0;
        for (int i = 0; i < game.map.map.Count; i++)
        {
            var tale = game.map[i];
            
            Console.SetCursorPosition(0, line);
            Console.Write($"{tale.Name}");

            foreach (var player in game.players)
            {
                if (player.currentPosition == i)
                {
                    Console.Write($" {player.Name} ");
                }
            }

            line++;
        }

        var currentPlayer = game.players[game.currentPlayer];
        var currentTale = game.map[currentPlayer.currentPosition];

        int cursorY = 0;
        Console.SetCursorPosition(120, cursorY++);
        Console.WriteLine("=== Players ===");

        foreach (var player in game.players)
        {
            Console.SetCursorPosition(120, cursorY++);
            Console.WriteLine($"{player.Name}: {player.wallet.AmountMoney}$");
        }

        Console.SetCursorPosition(120, cursorY++);
        Console.WriteLine("=== Current tale ===");
        Console.SetCursorPosition(120, cursorY++);
        Console.WriteLine($"{currentTale.Name}: {currentPlayer.Name}");

        if (currentTale is PropertyTale propertyTale)
        {
            if(propertyTale.owner == null)
            {
                Console.SetCursorPosition(120, cursorY++);
                Console.WriteLine($"Owner: none");
            }
            else if (propertyTale.owner != null)
            {
                Console.SetCursorPosition(120, cursorY++);
                Console.WriteLine($"Owner: {propertyTale.owner.Name}");
            }
            Console.SetCursorPosition(120, cursorY++);
            Console.WriteLine($"Price: {propertyTale.Price}$");
            if(propertyTale is TaleWithHouse houseTale)
            {
                Console.SetCursorPosition(120, cursorY++);
                Console.WriteLine($"Houses: {houseTale.houses.Count}");

                if (houseTale.hotel == null)
                {
                    Console.SetCursorPosition(120, cursorY++);
                    Console.WriteLine($"Hotel: 0");
                }
                else
                {
                    Console.SetCursorPosition(120, cursorY++);
                    Console.WriteLine($"Hotel: 1");
                }
            }
        }
    }
}