class MovePlayerState : IGameState
{
    public void HandleInput(Game game)
    {
        var currentPlayer = game.players[game.currentPlayer];
        
        currentPlayer.NextStep();
        game.NextPlayer();
    }

    public void Render()
    {}
}