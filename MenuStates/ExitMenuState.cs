class ExitMenuState : IMenuState
{
    public void HandleInput(Menu menu)
    {
        Environment.Exit(0);
    }

    public void Render()
    {
        Console.Clear();
    }
}