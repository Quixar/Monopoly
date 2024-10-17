using System.ComponentModel.Design;

class MainMenuState : IState
{
    int selectedIndex = 0;
    string[] menuOptions = { "Play", "Rules", "Exit"};

    public void HandleInput(Game game)
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        if(keyInfo.Key == ConsoleKey.UpArrow)
        {
            selectedIndex = (selectedIndex == 0) ? menuOptions.Length - 1: selectedIndex - 1;
        }

        else if (keyInfo.Key == ConsoleKey.DownArrow)
        {
            selectedIndex = (selectedIndex == menuOptions.Length - 1) ? 0 : selectedIndex + 1;
        }

        else if (keyInfo.Key == ConsoleKey.Enter)
        {
            switch (selectedIndex)
            {
                case 0:
                    game.ChangeState(new StartGameState());
                    break;
                case 1:
                    game.ChangeState(new RuleMenuState());
                    break;
                case 2:
                    game.ChangeState(new ExitMenuState());
                    break;
            }
        }
    }

    public void Render()
    {
        Console.Clear();
        string title = "MONOPOLY";
        Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.WindowHeight / 4);
        Console.WriteLine(title);

        for (int i = 0; i < menuOptions.Length; i++)
        {
            if (i == selectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.SetCursorPosition((Console.WindowWidth - menuOptions[i].Length) / 2, Console.WindowHeight / 2 + i);
            Console.WriteLine(menuOptions[i]);
        }
        Console.ResetColor();
    }
}