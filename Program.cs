using Monopoly_game;
using System.Diagnostics;

namespace Monopoly_game
{
    public class Field
    {
        char[,] field;
        public Field()
        {
            this.field = new char[Console.LargestWindowHeight, Console.LargestWindowWidth];
        }

        public void CreateField()
        {
            for (int i = 0; i < Console.LargestWindowHeight; i++)
            {
                for (int j = 0; j < Console.LargestWindowWidth; j++)
                {
                    if (i == 0 || j == 0 || i == Console.LargestWindowHeight - 1 || j == Console.LargestWindowWidth - 1)
                    {
                        field[i, j] = '#';
                    }
                    else
                    {
                        field[i, j] = ' ';
                    }
                    if (i == 15 || i == Console.LargestWindowHeight - 15 || j == 40 || j == Console.LargestWindowWidth - 40)
                    {
                        field[i, j] = '#';
                    }
                }
            }
        }

        public void PrintField()
        {
            for (int i = 0; i < Console.LargestWindowHeight; i++)
            {
                for (int j = 0; j < Console.LargestWindowWidth; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }

    } 
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop);
            Field field = new Field();
            field.CreateField();
            field.PrintField();
        }
    }
}