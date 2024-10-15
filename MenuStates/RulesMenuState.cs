class RulesMenuState : IMenuState
{
    public void HandleInput(Menu menu)
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        if (keyInfo.Key == ConsoleKey.Escape)
        {
            menu.ChangeState(new MainMenuState());
        }
    }

    public void Render()
    {
        Console.Clear();

        string rulesText = "Rules of the Monopoly game:\n\n" +
                           "1. Players roll dice to move around the playing field.\n" +
                           "2. If a player comes across an unoccupied object, he can buy it.\n" +
                           "3. If a player enters an object owned by another player, he must pay rent.\n" +
                           "\nPress Escape to return to the main menu.";

        string[] lines = rulesText.Split('\n');
        int startY = (Console.WindowHeight / 2) - (lines.Length / 2);

        for (int i = 0; i < lines.Length; i++)
        {
            Console.SetCursorPosition((Console.WindowWidth - lines[i].Length) / 2, startY + i);
            Console.WriteLine(lines[i]);
        }
    }

}