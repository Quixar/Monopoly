class Wallet
{
    public double AmountMoney {get; set; }

    public Wallet(double amountMoney)
    {
        AmountMoney = amountMoney;
    }
    
    public Wallet() : this(1500)
    {

    }
}