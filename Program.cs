using System;

class Program
{
    static void ProcessNumber(
        int number,
        out bool isEven,
        out bool isPositive,
        out bool isPrime)
    {
        // Чи є число парним
        isEven = number % 2 == 0;

        // Чи є число додатним
        isPositive = number > 0;

        // Чи є число простим
        isPrime = true;

        if (number < 2)
        {
            isPrime = false;
        }
        else
        {
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
        }
    }

    static void Main()
    {
        Console.Write("Введіть ціле число: ");
        int number = int.Parse(Console.ReadLine());

        bool isEven;
        bool isPositive;
        bool isPrime;

        ProcessNumber(
            number,
            out isEven,
            out isPositive,
            out isPrime
        );

        Console.WriteLine($"Парне: {isEven}");
        Console.WriteLine($"Додатне: {isPositive}");
        Console.WriteLine($"Просте: {isPrime}");
        Console.ReadKey();
    }
}