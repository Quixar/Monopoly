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
        this.map[currentPosition + rollValue].OnStep(this); 
        currentPosition += rollValue;
    }

    public void PayRent() 
    {
        if (map[currentPosition] is TaleWithHouse tale && tale.owner != null && tale.owner != this) 
        {
            int rentToPay = 0;

            if (wallet.AmountMoney >= tale.Rent1) 
            {
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
                else if (tale.houses.Count == 0) 
                {
                    rentToPay = tale.Rent1;
                }

                wallet.AmountMoney -= rentToPay;
                tale.owner.wallet.AmountMoney += rentToPay;
                Console.WriteLine($"{Name} paid {rentToPay} to {tale.owner.Name}.");
            } 
            else 
            {
                Console.WriteLine($"{Name} doesn't have enough money to pay rent!"); // ToDo - логика проигрыша
            }
        }
    }
}