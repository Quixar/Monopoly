class House
{
    public double Price { get; private set; }
    public House(double price)
    {
        Price = price;
    }

    public House() : this(150)
    {
    }
}