class StartTale : EventTale
{
    public StartTale(string name) : base(name)
    {
        Name = name;
    }

    public override void OnStep(Player player)
    {
        player.wallet.AmountMoney += 200;
        player.NextStep();
    }
}