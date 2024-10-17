class Player
{
    public Wallet wallet;
    public Map map;
    public Dice dice = new Dice();
    public int currentPosition;
    public bool isBankrupt;
    public bool isInJail;
    public string Name { get; set; }
    public int turnsToSkip;
    public int rentToPay;
    public Player(Map map, string name)
    {
        rentToPay = 0;
        Name = name;
        wallet = new Wallet(1100);
        isBankrupt = false;
        this.map = map;
        currentPosition = 0;
        turnsToSkip = 0;
    }
    public void NextStep()
    {
        if(isInJail)
        {
            if (turnsToSkip > 0)
            {   
                Console.SetCursorPosition(120, 18);
                Console.WriteLine($"{Name} is in prison for another {turnsToSkip} turn");
                turnsToSkip--;
            }
            else 
            {
                Console.SetCursorPosition(120, 19);
                System.Console.WriteLine($"{Name} was released from prison");
                isInJail = false;
            }
        }
        if (isBankrupt)
        {
            return;
        }
        int rollValue = dice.Roll();
        currentPosition += rollValue;
        currentPosition = currentPosition % map.map.Count;
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
                Console.SetCursorPosition(120, 18);
                Console.WriteLine($"{Name} doesn't have enough money to pay rent!");
                DeclareBankrupt(tale.owner);
            }
        }
    }
    public void PayRentForUtilityTale()
    {
        if (map[currentPosition] is UtilityTale utility && utility.owner != null && utility.owner != this)
        {
            if (utility.owner.GetUtilityCount() == 1)
            {
                rentToPay = dice.Roll() * utility.RentMultiplierSingle;
            }
            else if (utility.owner.GetUtilityCount() == 2)
            {
                rentToPay = dice.Roll() * utility.RentMultiplierBoth;
            }
            if (wallet.AmountMoney >= rentToPay)
            {
                wallet.AmountMoney -= rentToPay;
                utility.owner.wallet.AmountMoney += rentToPay;
            }
            else
            {
                Console.SetCursorPosition(120, 18);
                Console.WriteLine($"{Name} doesn't have enough money to pay rent!");
                DeclareBankrupt(utility.owner);
            }
        }
    }
    public void PayRentForRailroadTale()
    {
        if (map[currentPosition] is RailroadTale railroad && railroad.owner != null && railroad.owner != this)
        {
            int rentToPay = 0;
            if (railroad.owner.GetRailroadCount() == 1)
            {
                rentToPay = railroad.Rent1;
            }
            else if (railroad.owner.GetRailroadCount() == 2)
            {
                rentToPay = railroad.Rent2;
            }
            else if (railroad.owner.GetRailroadCount() == 3)
            {
                rentToPay = railroad.Rent3;
            }
            else if (railroad.owner.GetRailroadCount() == 4)
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
                Console.SetCursorPosition(120, 18);
                Console.WriteLine($"{Name} doesn't have enough money to pay rent!");
                DeclareBankrupt(railroad.owner);
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
    public int GetUtilityCount()
    {
        int count = 0;
        foreach (var tale in map)
        {
            if (tale is UtilityTale utility && utility.owner == this)
            {
                count++;
            }
        }
        return count;
    }
    public void TransferProperty(Player creditor)
    {
        foreach (var tale in map)
        {
            if (tale is PropertyTale propertyTale && propertyTale.owner == this)
            {
                propertyTale.owner = creditor;
            }
        }
        wallet.AmountMoney = 0;
    }
    public void DeclareBankrupt(Player creditor)
    {
        TransferProperty(creditor);
        wallet.AmountMoney = 0;
        isBankrupt = true;
    }
    public void GoToJail()
    {
        turnsToSkip = 3;
        isInJail = true;
    }
    public void GoToParking()
    {
        turnsToSkip = 1;
    }
    public void MoveToStart()
    {
        currentPosition = 0;
        wallet.AmountMoney += 200;
    }
}