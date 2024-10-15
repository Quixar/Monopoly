class JailTale : EventTale
{
    public JailTale(string name) : base(name)
    {
        Name = name;
    }

    public override void OnStep(Player player)
    {
        player.GoToJail();
    }
}