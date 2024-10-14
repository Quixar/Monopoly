class EventTale : Tale
{
    public EventTale(string name) : base(name)
    {
        Name = name;
    }

    public override void Draw()
    {
        throw new NotImplementedException();
    }

    public override void OnStep(Player player)
    {
        
    }
}