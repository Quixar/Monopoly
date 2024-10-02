using Monopoly_game;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Monopoly_game
{
    internal class Case
    {
        char[,] field;
        bool condition; //куплен или нет
        string house;
        string text;
        static int count = 0;

        public Case() : this(15, 16) { }
        public Case(int length, int height)
        {
            field = new char[length, height];
            house = " ";
            text = " ";
            condition = false;
        }

        public void CreateField()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (i == 0 || j == 0 || i == field.GetLength(0) - 1 || j == field.GetLength(1) - 1)
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
            //bool position = false;
            for (int i = 0; i < field.GetLength(0); i++)
            {            
                for (int j = 0; j < field.GetLength(1); j++)
                {                    
                    Console.Write(field[i, j]);
                }

                Console.WriteLine();


                if (count != 0 && i != field.GetLength(0) - 1)
                {
                    Console.SetCursorPosition(count, i + 1);
                }

                if (i == field.GetLength(0) - 1)
                {
                    count += field.GetLength(1);
                    Console.SetCursorPosition(count, 0);
                    if(count == field.GetLength(1) * 5)
                    {
                        Console.SetCursorPosition(0, field.GetLength(0));
                        count = 0;
                    }
                }                 
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
                    this.field[i, j] = new Case(15, 8);
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
                //Console.WriteLine();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            //Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            //Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            
            //Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop);

            Field field = new Field();
            field.CreateField();
            field.PrintField();
        }
    }
}