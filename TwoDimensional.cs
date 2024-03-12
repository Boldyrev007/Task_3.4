using System;
using System.Reflection.Emit;

namespace Task_Boldyrev;

public sealed class TwoDimensional<T> : BaseArray<T>, IPrinter
{
    private int rows, columns;
    private T[,] array;

    public TwoDimensional(bool choice = false, Valueprovider<T> inputgenerator): base(choice, inputgenerator)
    {
        array = new T[rows, columns];
        Create(choice);
    }

    protected override void fillArray_by_User()
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = generator.ConvertFromString(Console.ReadLine()); ;
            }
        }

    }

    public override void Create(bool choice)
    {
        // input length here
        Console.WriteLine("Введите длину массива: ");
        int rows = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите ширину массива: ");
        int columns = Convert.ToInt32(Console.ReadLine());
        array = new T[rows, columns];
        base.Create(choice);
    }

    protected override void fill_RandomArray()
    {
        Random random = new Random();
        int length = random.Next(1, 11);
        int width = random.Next(1, 11);
        array = new T[length, width];
        for (int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                array[i, j] = generator.Generate(); ;
            }
        }
    }

    private int[,] GetTwoDimensionalArray(int rows, int columns)
    {
        Random random = new Random();
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = generator.Generate();
            }
            Console.WriteLine();
        }
        return array;
    }

    public override void Print()
    {
        Console.WriteLine("\nЗадание 2.1");
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.Write("\n");
        }
    }

    void IPrinter.Print() {

        Console.WriteLine("\nЗадание 2.2");

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                var element = i % 2 == 0
                    ? array[i, array.GetLength(1) - 1 - j]
                    : array[i, j];
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

