class ExitMenuState : IState
{
    public void HandleInput(Game menu)
    {
        Environment.Exit(0);
    }

    public void Render()
    {
        Console.Clear();
    }
}