class Game
{
    IGameState currentState;

    public Game(IGameState initState)
    {
        currentState = initState;
    }

    public void ChangeState(IGameState newState)
    {
        currentState = newState;
    }

    public void HandleInput()
    {
        currentState.HandleInput(this);
    }

    public void Render()
    {
        currentState.Render();
    }
}