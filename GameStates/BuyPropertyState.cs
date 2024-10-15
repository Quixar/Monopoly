class BuyPropertyState : IGameState
{
    public void HandleInput(Game game)
    {
        System.Console.WriteLine("This tale is available for purchase. Do you want to buy it? (Y/N)");
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        if (keyInfo.Key == ConsoleKey.Y)
        {
            
        }
    }

    public void Render()
    {

    }
}