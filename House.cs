class House
{
    public int Price { get; private set; }
    public House(int price)
    {
        Price = price;
    }

    public House() : this(50)
    {
    }
}