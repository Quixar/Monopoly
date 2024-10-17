class TaxTale : EventTale
{
    public int TaxAmount { get; set; }

    public TaxTale(string name, int taxAmount) : base(name)
    {
        TaxAmount = taxAmount;
    }

    public override void OnStep(Player player)
    {
        int cursorY = 16;

        if (player.wallet.AmountMoney >= TaxAmount)
        {
            player.wallet.AmountMoney -= TaxAmount;
            Console.SetCursorPosition(120, cursorY++);
            Console.WriteLine($"Player {player.Name} paid {TaxAmount}$ tax.");
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine("Press any key to continue");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            player.NextStep();
        }
        else
        {
            player.DeclareBankrupt(null);
            Console.SetCursorPosition(120, cursorY++);
            Console.WriteLine($"Player {player.Name} doesn't have enough money to pay the tax and is bankrupt.");
            Console.SetCursorPosition(120, cursorY++);
            System.Console.WriteLine("Press any key to continue");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        }
    }
}