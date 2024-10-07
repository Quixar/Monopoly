class PropertyTale : Tale
{
    public int Price { get; set; }
    public bool IsSold { get; set; }
    public int PropertySellPrice { get; set; }
    public PropertyTale(string name, int price, int propertySellPrice) : base(name)
    {
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