class MainMenuState : IMenuState
{
    int selectedIndex = 0;
    string[] menuOptions = { "Play", "Rules", "Exit"};

    public void HandleInput(Menu menu)
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        if (keyInfo.Key == ConsoleKey.UpArrow)
        {
            selectedIndex = (selectedIndex == 0) ? menuOptions.Length - 1 : selectedIndex - 1;
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
                    // To Do сделать состояние перехода в новую игру
                    Console.WriteLine("Переход к игре...");
                    break;
                case 1:
                    menu.ChangeState(new RulesMenuState());
                    break;
                case 2:
                    menu.ChangeState(new ExitMenuState());
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
                Console.ForegroundColor = ConsoleColor.Cyan;  // Выделение выбранного пункта
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