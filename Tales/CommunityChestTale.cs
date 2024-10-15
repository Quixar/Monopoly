class CommunityChestTale : EventTale
{
    List<Action<Player>> chestCards;
    Random random;
    public CommunityChestTale() : base("Chest")
    {
        random = new Random();
        InitCommunityCards();
    }

    void InitCommunityCards()
    {
        chestCards = new List<Action<Player>>
        {
            player => { player.wallet.AmountMoney += 200;},
            player => { player.wallet.AmountMoney -= 100;},
            player => { player.wallet.AmountMoney += 10;},
            player => { player.wallet.AmountMoney -= 50;},
            player => { player.wallet.AmountMoney += 100;},
            player => { player.MoveToStart();}
        };
    }

    public override void OnStep(Player player)
    {
        int cardIndex = random.Next(chestCards.Count);
        chestCards[cardIndex]?.Invoke(player);
    }
}