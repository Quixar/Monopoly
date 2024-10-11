class PropertyTale : Tale
{
    public int Price { get; set; }
    public bool IsSold { get; set; }
    public int PropertySellPrice { get; set; }
    public Player owner;

    public PropertyTale(string name, int price, int propertySellPrice) : base(name)
    {
        owner = null;
        Price = price;
        PropertySellPrice = propertySellPrice;
        IsSold = false;
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