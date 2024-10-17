class ParkingTale : EventTale
{
    public ParkingTale(string name) : base(name)
    {
        Name = name;
    }

    public override void OnStep(Player player)
    {
        int cursorY = 16;

        player.GoToParking();

        Console.SetCursorPosition(120, cursorY++);
        Console.WriteLine($"Player {player.Name} has gone to Parking.");

    }
}