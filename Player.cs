class Player
{
    public Wallet wallet;
    Map map;
    Dice dice = new Dice();
    int currentPosition;
    public string Name { get; set; }

    public Player(Map map)
    {
        this.map = map;
        currentPosition = 0;
    }

    public void NextStep()
    {
        int rollValue = dice.Roll();
        map[currentPosition + rollValue].OnStep(this); 
        currentPosition += rollValue;
    }

    public void PayRentForTaleWithHouse() 
    {
        if (map[currentPosition] is TaleWithHouse tale && tale.owner != null && tale.owner != this) 
        {
            int rentToPay = 0;

            if (tale.hotel != null) 
            {
                rentToPay = tale.Rent6;
            } 
            else if (tale.houses.Count == 4) 
            {
                rentToPay = tale.Rent5;
            }
            else if (tale.houses.Count == 3) 
            {
                rentToPay = tale.Rent4;
            }
            else if (tale.houses.Count == 2) 
            {
                rentToPay = tale.Rent3;
            }
            else if (tale.houses.Count == 1) 
            {
                rentToPay = tale.Rent2;
            }
            else 
            {
                rentToPay = tale.Rent1;
            }

            if (wallet.AmountMoney >= rentToPay) 
            {
                wallet.AmountMoney -= rentToPay;
                tale.owner.wallet.AmountMoney += rentToPay;
            } 
            else 
            {
                Console.WriteLine($"{Name} doesn't have enough money to pay rent!"); // ToDo - логика проигрыша
            }
        }
    }


    public void PayRentForRailroadTale()
    {
        if (map[currentPosition] is RailroadTale railroad && railroad.owner != null && railroad.owner != this)
        {
            int rentToPay = 0;

            if (GetRailroadCount() == 1)
            {
                rentToPay = railroad.Rent1;
            }
            else if (GetRailroadCount() == 2)
            {
                rentToPay = railroad.Rent2;
            }
            else if (GetRailroadCount() == 3)
            {
                rentToPay = railroad.Rent3;
            }
            else if (GetRailroadCount() == 4)
            {
                rentToPay = railroad.Rent4;
            }

            if (wallet.AmountMoney >= rentToPay) 
            {
                wallet.AmountMoney -= rentToPay;
                railroad.owner.wallet.AmountMoney += rentToPay;
            } 
            else 
            {
                Console.WriteLine($"{Name} doesn't have enough money to pay rent!"); // ToDo - логика проигрыша
            }
        }
    }

    public int GetRailroadCount()
    {
        int count = 0;
        foreach (var tale in map)
        {
            if (tale is RailroadTale railroad && railroad.owner == this)
            {
                count++;
            }
        }
        return count;
    }
}