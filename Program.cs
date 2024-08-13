using Monopoly_game;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Monopoly_game
{
    internal class Case
    {
        char[,] field;
        int length;
        int height;
        bool condition;//куплен или нет
        string house;
        string text;

        public Case() : this(15, 16) { }
        public Case(int length, int height)
        {
            field = new char[length, height];
            this.length = length;
            this.height = height;
            house = " ";
            text = " ";
            condition = false;
        }

        public void CreateField()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == 0 || j == 0 || i == this.height - 1 || j == this.length - 1)
                    {
                        field[i, j] = '#';
                    }

                    else
                    {
                        field[i, j] = ' ';
                    }
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }
    }

    public class Field
    {
        Case[,] field = new Case[4, 5];

        public Field()
        {
            for(int i = 0; i < field.GetLength(0) ; i++)
            {
                for(int j = 0; j < field.GetLength(1); j++)
                {
                    this.field[i, j] = new Case(5, 15);
                }
            }
        }

        public void CreateField()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j].CreateField();
                }
            }
        }

        public void PrintField()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j].Print();
                }
                Console.WriteLine();
            }
        }
    } 
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            
            Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop);

            Field field = new Field();
            field.CreateField();
            field.PrintField();
        }
    }
}