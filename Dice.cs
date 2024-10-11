class Dice
{
    Random random= new Random();
    int value;

    public int Roll()
    {
        value = random.Next(1, 7);
        System.Console.WriteLine($"You're moving {value} tales");
        return value;
    } 
}