class StartTale : EventTale
{
    public StartTale(string name) : base(name)
    {
        Name = name;
    }

    public override void OnStep(Player player)
    {
        int cursorY = 16;

        player.wallet.AmountMoney += 200;

        Console.SetCursorPosition(120, cursorY++);
        Console.WriteLine($"Player {player.Name} received 200$.");

        player.NextStep();
    }
}