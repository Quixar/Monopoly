class RollDiceState : IGameState
{
    Dice dice = new Dice();
    public void HandleInput(Game game)
    {
        System.Console.WriteLine("Press Enter to roll the dice");
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        if(keyInfo.Key == ConsoleKey.Enter)
        {
            int rollValue = dice.Roll();
            Render();
        }
    }

    public void Render()
    {
        /*int width = 22;
        int height = 11; 
        int centerX = width / 2 - 3;  
        int centerY = height / 2 - 1; 

        Console.ForegroundColor = ConsoleColor.White;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if ((i >= centerY && i < centerY + 3) && (j >= centerX && j < centerX + 6))
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("█");
                }
                else if (((i >= 2 && i < 4) && (j >= 4 && j < 7) || 
                (i >= height - 4 && i < height - 2) && (j >= width - 7 && j < width - 4)))
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("█");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White; 
                    Console.Write("█");
                }
            }
            Console.WriteLine();
        }

        Console.ResetColor();*/
    }
}