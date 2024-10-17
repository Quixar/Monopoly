class JailTale : EventTale
{
    public JailTale(string name) : base(name)
    {
        Name = name;
    }

    public override void OnStep(Player player)
    {
        int cursorY = 16;

        Console.SetCursorPosition(120, cursorY++);
        Console.WriteLine($"Player {player.Name} has gone to Jail");

        player.GoToJail();
    }
}