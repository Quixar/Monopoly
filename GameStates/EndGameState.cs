class EndGameState : IState
{
    public void HandleInput(Game game)
    {
        Console.Clear();
        
        int windowWidth = Console.WindowWidth;
        
        string gameOverMessage = "=== GAME OVER ===";
        string winnerMessage = $"Winner: {game.players[0].Name}";
        string thanksMessage = "Thank you for playing!";
        string exitMessage = "Press any key to exit...";

        int centerXGameOver = (windowWidth - gameOverMessage.Length) / 2;
        int centerXWinner = (windowWidth - winnerMessage.Length) / 2;
        int centerXThanks = (windowWidth - thanksMessage.Length) / 2;
        int centerXExit = (windowWidth - exitMessage.Length) / 2;

        Console.SetCursorPosition(centerXGameOver, Console.WindowHeight / 2 - 2);
        Console.WriteLine(gameOverMessage);

        Console.SetCursorPosition(centerXWinner, Console.WindowHeight / 2);
        Console.WriteLine(winnerMessage);

        Console.SetCursorPosition(centerXThanks, Console.WindowHeight / 2 + 2);
        Console.WriteLine(thanksMessage);

        Console.SetCursorPosition(centerXExit, Console.WindowHeight / 2 + 4);
        Console.WriteLine(exitMessage);

        Console.ReadKey();
        game.ChangeState(new ExitMenuState());
    }

    public void Render() {}
}