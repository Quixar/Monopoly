class PlayerTurnState : IState
{
    public void HandleInput(Game game)
    {
        
        var currentPlayer = game.players[game.currentPlayer];
        int cursorY = 15;
        Console.SetCursorPosition(120, cursorY++);
        Console.WriteLine($"It's {currentPlayer.Name}'s turn!");
        //currentPlayer.NextStep();

        game.map[currentPlayer.currentPosition].OnStep(currentPlayer);

        if (currentPlayer.isBankrupt)
        {
            Console.SetCursorPosition(120, cursorY++);
            Console.WriteLine($"{currentPlayer.Name} is bankrupt!");
            game.RemovePlayer(currentPlayer);

            if (game.players.Count == 1)
            {
                game.ChangeState(new EndGameState());
                return;
            }
        }

        game.gameStateRenderer.RenderMap(game);
        game.NextPlayer();
        game.ChangeState(new PlayerTurnState());
    }

    public void Render()
    {
        
    }
}