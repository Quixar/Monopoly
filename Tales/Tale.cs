abstract class Tale
{
    public string Name { get; set; }

    public Tale(string name)
    {
        Name = name;
    }

    public void ShowInfo(string text)
    {
        System.Console.WriteLine(text);
    }

    abstract public void OnStep(Player player);
}