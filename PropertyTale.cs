class PropertyTale : Tale
{
    public int Price { get; set; }
    public int PropertySellPrice { get; set; }
    public Player owner;

    public PropertyTale(string name, int price) : base(name)
    {
        owner = null;
        Price = price;
        PropertySellPrice = price / 2;
    }

    public override void Draw()
    {
        System.Console.WriteLine(Name);
        System.Console.WriteLine(Price);
        System.Console.WriteLine(PropertySellPrice);
    }

    public override void OnStep(Player player)
    {

    }
}