class ChanceTale : EventTale
{
    List<Action<Player>> chanceCards;
    Random random;

    public ChanceTale() : base("Chance")
    {
        random = new Random();
        InitChanceCards();
    }

    void InitChanceCards()
    {
        chanceCards = new List<Action<Player>>
        {
            player => { player.wallet.AmountMoney += 100;},
            player => { player.wallet.AmountMoney -= 50;},
            player => { player.wallet.AmountMoney += 200;},
            player => { player.MoveToStart();},
            player => { player.wallet.AmountMoney -= 150;},
            player => { player.wallet.AmountMoney += 50;},
            player => { player.wallet.AmountMoney -= 100;},
            player => { player.currentPosition -= 3;},
            player => { player.currentPosition += 5;}
        };
    }

    public override void OnStep(Player player)
    {
        int cardIndex = random.Next(chanceCards.Count);
        chanceCards[cardIndex]?.Invoke(player);

    }
}