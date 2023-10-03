using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Выбери действие:\n1. Игра \"Угадай число\"\n2. Таблица умножения\n3. Вывод делителей числа");
        int choice = int.Parse(Console.ReadLine());
       
        switch (choice)
        {
            case 1:
                GuessNumberGame();
                break;
            case 2:
                MultiplicationTable();
                break;
            case 3:
                PrintDivisors();
                break;
            default:
                Console.WriteLine("Сказано, от 1 до 3, ничего другого, игра окончена");
                break;
        }
    }

    static void GuessNumberGame()
    {
        Random random = new Random();
        int numberToGuess = random.Next(1, 101);
        int attempts = 0;
        bool guessed = false;

        Console.WriteLine("Игра \"Угадай число\"");
        Console.WriteLine("Я загадала число от 1 до 100. У тебя есть 15 попыток, чтобы его угадать.");

        while (!guessed && attempts < 15)
        {
            Console.Write("Введи предположение: ");
            int guess = int.Parse(Console.ReadLine());
            attempts++;

            if (guess == numberToGuess)
            {
                Console.WriteLine("Вау, ты угадал мое число.");
                guessed = true;
            }
            else if (guess < numberToGuess)
            {
                Console.WriteLine("Неа, мое число больше твоего предположения.");
            }
            else
            {
                Console.WriteLine("Неа, мое число меньше твоего предположения.");
            }
        }

        if (!guessed)
        {
            Console.WriteLine("Твои попытки закончились, я загадала число: " + numberToGuess);
        }
    }

    static void MultiplicationTable()
    {
        Console.WriteLine("Таблица умножения:");

        for (int i = 1; i <= 10; i++)
        {
            for (int j = 1; j <= 10; j++)
            {
                Console.Write("{0,4}", i * j);
            }
            Console.WriteLine();
        }
    }

    static void PrintDivisors()
    {
        Console.Write("Введи число: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("Делители числа " + number + ":");

        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}
