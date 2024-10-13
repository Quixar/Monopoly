class EventTale : Tale
{
    public event TaleDelegate OnTaleStep;
    public delegate void TaleDelegate(Player player);
    public EventTale(string? name) : base(name)
    {

    }

    public override void Draw()
    {
        throw new NotImplementedException();
    }

    public override void OnStep(Player player)
    {
        OnTaleStep?.Invoke(player);
    }
}