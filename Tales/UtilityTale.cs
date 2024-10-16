class UtilityTale : PropertyTale, IPurchasable
{
    public int RentMultiplierSingle { get; set; }
    public int RentMultiplierBoth { get; set; }

    public UtilityTale(string name)
        : base(name, 150)
    {
        RentMultiplierSingle = 4;
        RentMultiplierBoth = 10;
    }

    public void BuyTale(Player buyer)
    {
        if (owner == null)
        {
            if (buyer.wallet.AmountMoney >= Price)
            {
                buyer.wallet.AmountMoney -= Price;
                owner = buyer;
            }
            else
            {
                Console.WriteLine($"{buyer.Name} не хватает денег для покупки {Name}.");
            }
        }
    }

    public void SellTale(Player buyer, Player seller)
    {
        if (owner != null)
        {
            if (buyer.wallet.AmountMoney >= PropertySellPrice)
            {
                buyer.wallet.AmountMoney -= PropertySellPrice;
                seller.wallet.AmountMoney += PropertySellPrice;
                owner = buyer;
            }
            else
            {
                Console.WriteLine($"{buyer.Name} не хватает денег для покупки {Name}.");
            }
        }
    }

    public override void OnStep(Player player)
    {
        if (owner == null)
        {
            Console.WriteLine($"Player {player.Name}, do you want to buy {Name} for {Price}? (Y/N)");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Y)
            {
                if (player.wallet.AmountMoney >= Price)
                {
                    BuyTale(player);
                    Console.WriteLine($"{player.Name} bought {Name} for {Price}.");
                }
                else
                {
                    Console.WriteLine($"{player.Name} doesn't have enough money to buy {Name}.");
                }
            }
            else
            {
                Console.WriteLine($"{player.Name} decided not to buy {Name}.");
            }
        }
        else if (owner != null && owner != player)
        {
            player.PayRentForUtilityTale();
        }
        else if (player == owner)
        {
            Console.WriteLine($"Player {player.Name} already owns {Name}.");
        }

        player.NextStep();
    }
}