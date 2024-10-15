class ParkingTale : EventTale
{
    public ParkingTale(string name) : base(name)
    {
        Name = name;
    }

    public override void OnStep(Player player)
    {
        player.GoToParking();
    }
}