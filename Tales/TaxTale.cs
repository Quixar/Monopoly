class TaxTale : EventTale
{
    public int TaxAmount { get; set; }

    public TaxTale(string name, int taxAmount) : base(name)
    {
        TaxAmount = taxAmount;
    }

    public override void OnStep(Player player)
    {
        if (player.wallet.AmountMoney >= TaxAmount)
        {
            player.wallet.AmountMoney -= TaxAmount;
        }
        else
        {
            player.DeclareBankrupt(null);
        }
    }
}