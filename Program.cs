using System;

namespace Task_Boldyrev;

class MainClass
{
    public static void Main()
    {
        Console.WriteLine("Массив будет вручную(0) или автоматически(1)? ");
        bool choice = Choice_Main_or_Auto();
        IPrinter[] printer = new IPrinter[8];
        Generate_Int generate_int = new Generate_Int();
        GenerateDouble generatedouble = new GenerateDouble();
        GenerateString generatestring = new GenerateString();
        GenerateBoolen generateboolen = new GenerateBoolen();
        printer[0] = new OneDimensional<int>(choice, generate_int);
        printer[1] = new OneDimensional<double>(choice, generatedouble);
        printer[2] = new OneDimensional<string>(choice, generatestring);
        printer[3] = new OneDimensional<bool>(choice, generateboolen);
        printer[4] = new TwoDimensional<int>(choice, generate_int);
        printer[5] = new TwoDimensional<double>(choice, generatedouble);
        printer[6] = new TwoDimensional<string>(choice, generatedouble);
        printer[7] = new TwoDimensional<bool>(choice, generateboolen);

        for(int i = 0; i < printer.Length; i++)
        {
            Console.WriteLine("Напечатанный массив: ");
            printer[i].Print();
        }


        //Console.WriteLine("One-Dimensional");
        //Console.WriteLine("Ввидите длину массива: ");
        //int length = int.Parse(Console.ReadLine());
        //OneDimensional array_onedimensional = new OneDimensional(choice);
        //Console.WriteLine("\nХотите ли вы пересоздать массив да(1)/нет(0)?");
        //choice = Choice_Main_or_Auto();


        //Console.WriteLine();
        //Console.WriteLine("Two-Dimensional");
        //(int, int) twoInput = Input();
        //TwoDimensional array_twodimensional = new TwoDimensional(twoInput.Item1, twoInput.Item2);
        //Console.WriteLine("\nХотите ли вы пересоздать массив да(1)/нет(0)?");
        //choice = Choice_Main_or_Auto();



        //IBaseArray[] arrays = new IBaseArray[] { array_onedimensional, array_twodimensional};

        for (int l = 0; l < arrays.Length; l++)
        {
            decimal x = arrays[l].Average_Value();
            Console.WriteLine("Среднее значение массиива: ", x);

            arrays[l].Create(choice);

        }

        IPrinter[] printers = new IPrinter[] {array_onedimensional, array_twodimensional};
        for(int i = 0; i < printers.Length; i++)
        {
            printers[i].Print();
        }

        Console.ReadKey();
    }

    static bool Choice_Main_or_Auto()
    {
        int a = int.Parse(Console.ReadLine());
        bool choice = true;
        if(a == 0)
        {
            choice = false;
        }
        else if(a == 1)
        {
            choice = true;
        }
        return choice;
    }

    static (int, int) Input()
    {
        Console.WriteLine("Введите число строчек в массиве: ");
        int rows = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите число колоннок в массиве: ");
        int columns = int.Parse(Console.ReadLine());
        return(rows, columns);
    }

    static int InputJaggedDimensional()
    {
        Console.WriteLine("Введите число строчек в массиве: ");
        int rows = int.Parse(Console.ReadLine());
        return rows;
    }


}



