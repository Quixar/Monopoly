class Hotel
{
    public double Price { get; private set;}

    public Hotel(double price)
    {
        Price = price;
    }

    public Hotel() : this(150)
    {
        
    }
}