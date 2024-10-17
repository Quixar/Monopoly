class StartGameState : IState
{
    public void HandleInput(Game game)
    {
        game.players.Add(new Player(game.map, "Player 1"));
        game.players.Add(new Player(game.map, "Player 2"));
        foreach(var player in game.players)
        {
            player.MoveToStart();
        }
        game.gameStateRenderer.RenderMap(game);
        
        game.ChangeState(new PlayerTurnState());
    }
    public void Render()
    {
        
    }
}