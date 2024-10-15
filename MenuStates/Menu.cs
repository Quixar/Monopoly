class Menu 
{
    IMenuState currentState;

    public Menu(IMenuState initState)
    {
        currentState = initState;
    }

    public void ChangeState(IMenuState newState)
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