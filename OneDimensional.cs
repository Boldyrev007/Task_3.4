using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task_Boldyrev;

public sealed class OneDimensional<T> : BaseArray<T>, IOneDimensionalArray
{
    private T[] array;

    public OneDimensional( bool choice, Valueprovider<T> inputgenerator) : base(choice, inputgenerator)
    {
        Create(choice);
    }

    protected override void fill_RandomArray()
    {
        Random random = new Random();
        int length = random.Next(1, 11);
        array = new T[length];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = generator.Generate();
        }
    }

    protected override void fillArray_by_User()
    {
        Console.WriteLine("Введите длину массива: ");
        int length = int.Parse(Console.ReadLine());

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = generator.ConvertFromString(Console.ReadLine());

        }
    }
    
    public override void Create(bool choice)
    {
        Console.WriteLine("Введите длину массива: ");
        int length = Convert.ToInt32(Console.ReadLine());
        array = new T[length];
        base.Create(choice);
    }

    private static bool Exists(int value, int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                return true;
            }
        }
        return false;
    }

    public override void Print()
    {
        foreach (var element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}

