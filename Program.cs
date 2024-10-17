using Monopoly_game;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Monopoly_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            
            while(true)
            {
                game.Render();
                game.HandleInput();
            }
        }
    }
}